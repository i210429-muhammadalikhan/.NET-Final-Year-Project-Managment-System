using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class FeedbackBySupervisor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int x = GetStudentId();
        int groupID = GetGroupIdByStudentId(x); // Replace with the actual group ID
        BindFeedback(groupID);
    }

    private void BindFeedback(int groupID)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT FeedbackText, AssignmentDescription, FeedbackDate FROM Feedback WHERE GroupID = @GroupID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvFeedback.DataSource = dt;
                    gvFeedback.DataBind();
                }
            }
        }
    }

    public int GetGroupIdByStudentId(int studentId)
    {
        // Replace with your actual database connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Check if the student is a group leader
        string leaderQuery = "SELECT group_id FROM Groups WHERE group_leader_id = @StudentId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand leaderCommand = new SqlCommand(leaderQuery, connection);
            leaderCommand.Parameters.AddWithValue("@StudentId", studentId);

            connection.Open();
            object leaderResult = leaderCommand.ExecuteScalar();

            if (leaderResult != null)
            {
                return Convert.ToInt32(leaderResult); // Student is a leader, return group ID
            }
            else
            {
                // Student is not a leader, check if they are a member
                string memberQuery = "SELECT group_id FROM Group_Members WHERE student_id = @StudentId";
                SqlCommand memberCommand = new SqlCommand(memberQuery, connection);
                memberCommand.Parameters.AddWithValue("@StudentId", studentId);

                object memberResult = memberCommand.ExecuteScalar();
                if (memberResult != null)
                {
                    return Convert.ToInt32(memberResult); // Student is a member, return group ID
                }
            }
        }

        return 0; // Student is not found in any group
    }

    private int GetStudentId()
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