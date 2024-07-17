using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MakeSubmissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubmissions();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string assignmentDetail = txtAssignmentDetail.Text;
        DateTime submissionTime = calSubmissionTime.SelectedDate;
        string submissionMedium = txtSubmissionMedium.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Submission (assignment_detail, submission_time, submission_medium) VALUES (@assignment_detail, @submission_time, @submission_medium)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@assignment_detail", assignmentDetail);
                cmd.Parameters.AddWithValue("@submission_time", submissionTime);
                cmd.Parameters.AddWithValue("@submission_medium", submissionMedium);
                cmd.ExecuteNonQuery();
                BindSubmissions();
            }
        }
    }

    private void BindSubmissions()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Submission";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvSubmissions.DataSource = dt;
                    gvSubmissions.DataBind();
                }
            }
        }
    }
}