using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UpdateSubmission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int submissionId = (int)Session["SelectedSubmissionId"];
            int x = GetLeaderId();

            int groupId = GetGroupIdByStudentId(x); // assume you have stored group ID in session


            lblSubmissionId.Text += submissionId.ToString();
            lblGroupId.Text += groupId.ToString();

            // Get the submission time from the Submission table
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT submission_time FROM Submission WHERE submission_id = @submissionId", conn);
                cmd.Parameters.AddWithValue("@submissionId", submissionId);
                DateTime submissionTime = (DateTime)cmd.ExecuteScalar();

                // Compare delivered time with submission time
                DateTime deliveredTime = DateTime.Now;
                if (deliveredTime <= submissionTime)
                {
                    lblSubmissionStatus.Text += "Submitted";
                }
                else
                {
                    lblSubmissionStatus.Text += "Submitted Late";
                }

                lblDeliveredTime.Text += deliveredTime.ToString();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int x = GetLeaderId();

        int groupId = GetGroupIdByStudentId(x);
        // Insert or update the SubmissionGroup table
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SubmissionGroup (submission_id, group_id, dilivered_time, submission_status, private_comment) VALUES (@submissionId, @groupId, @deliveredTime, @submissionStatus, @privateComment)", conn);
            cmd.Parameters.AddWithValue("@submissionId", (int)Session["SelectedSubmissionId"]);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@deliveredTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@submissionStatus", lblSubmissionStatus.Text);
            cmd.Parameters.AddWithValue("@privateComment", txtPrivateComment.Text);
            cmd.ExecuteNonQuery();
        }
    }


    public int GetGroupIdByStudentId(int studentId)
    {
        int groupId = -1; // Default value if no group is found

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"SELECT g.group_id
                             FROM Groups g
                             WHERE g.group_leader_id = @studentId
                             UNION
                             SELECT gm.group_id
                             FROM Group_Members gm
                             WHERE gm.student_id = @studentId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    groupId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        return groupId;
    }


    private int GetLeaderId()
    {
        int leaderId = 1;  // Default value to indicate not found
        string leaderEmail = Session["StudentEmail"] as string;
        // Retrieve the email from session
        if (string.IsNullOrEmpty(leaderEmail))
        {
            throw new InvalidOperationException("User email is not set in the session.");
        }

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT student_id FROM Students WHERE email = @Email", con))
            {
                cmd.Parameters.AddWithValue("@Email", leaderEmail);
                var result = cmd.ExecuteScalar(); // Executes query and returns the first column of the first row
                if (result != DBNull.Value)
                {
                    leaderId = Convert.ToInt32(result);
                }
            }
        }

        if (leaderId == -1)
        {
            throw new InvalidOperationException("No student found with the provided email.");
        }

        return leaderId;
    }

}