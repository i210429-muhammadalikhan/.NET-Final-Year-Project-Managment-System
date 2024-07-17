using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSubmissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubmissions();
        }
    }

    private void BindSubmissions()
    {
        // assumes you have a database connection string in your web.config file
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Submission", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Submission> submissions = new List<Submission>();

            while (reader.Read())
            {
                Submission submission = new Submission();
                submission.submission_id = (int)reader["submission_id"];
                submission.assignment_detail = (string)reader["assignment_detail"];
                submission.submission_time = (DateTime)reader["submission_time"];
                submission.submission_medium = (string)reader["submission_medium"];
                submissions.Add(submission);
            }

            gvSubmissions.DataSource = submissions;
            gvSubmissions.DataBind();
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Button btnSelect = (Button)sender;
        int submissionId = int.Parse(btnSelect.CommandArgument);

        // Get the submission time from the database or the gridview row



        Session["SelectedSubmissionId"] = submissionId;

        Response.Redirect("UpdateSubmission.aspx");
    }
}

public class Submission
{
    public int submission_id { get; set; }
    public string assignment_detail { get; set; }
    public DateTime submission_time { get; set; }
    public string submission_medium { get; set; }
}