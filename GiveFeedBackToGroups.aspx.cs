using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class GiveFeedBackToGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int supervisorid = GetSupervisoridId(); // Replace with the actual supervisor ID
            //int supervisorid = 13; // Replace with the actual supervisor ID

            BindGroups(supervisorid);
        }
    }

    protected void btnGiveFeedback_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int groupID = Convert.ToInt32(gvGroups.DataKeys[row.RowIndex].Value);
        pnlFeedback.Visible = true;
        ViewState["groupID"] = groupID;
    }

    protected void btnSubmitFeedback_Click(object sender, EventArgs e)
    {
        int groupID = (int)ViewState["groupID"];




        string feedback = txtFeedback.Text.Trim();
        string adescription = TextBox1.Text.Trim();


        if (feedback.Length <= 255 && adescription.Length <= 255)
        {
            // Both feedback and adescription lengths are within the acceptable boundary
            // Proceed with your logic here

            // For example, you can proceed with saving the data to a database or performing further operations
        }
        else
        {
            // Handle the error, perhaps by showing an error message to the user
            // For example, you can show a message indicating the maximum length allowed for each input
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Feedback and Description must be maximum 255 characters long.');", true);
        }




        if (!string.IsNullOrEmpty(feedback))
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Feedback (GroupID, FeedbackText, FeedbackDate,SupervisorID,AssignmentDescription) VALUES (@GroupID, @FeedbackText, @FeedbackDate , @SupervisorID ,@AssignmentDescription)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GroupID", groupID);
                    cmd.Parameters.AddWithValue("@FeedbackText", feedback);
                    cmd.Parameters.AddWithValue("@SupervisorID", GetSupervisoridId());
                    cmd.Parameters.AddWithValue("@AssignmentDescription", adescription);

                    cmd.Parameters.AddWithValue("@FeedbackDate", DateTime.Now); // Add current date and time as feedback date
                    cmd.ExecuteNonQuery();
                }
            }
            lblFeedbackStatus.Text = "Feedback submitted successfully!";
            pnlFeedback.Visible = false;
        }
        else
        {
            lblFeedbackStatus.Text = "Please enter feedback.";
        }
    }

    private void BindGroups(int supervisorid)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT   g.group_id AS GroupID,    p.project_title AS ProjectTitle,   p.leader_name AS LeaderName  FROM    Groups g INNER JOIN Project p ON g.project_title = p.project_title  INNER JOIN GroupSuperVisor gs ON gs.projectid = p.project_id  WHERE     gs.supervisorid = @supervisorid";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@supervisorid", supervisorid);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvGroups.DataSource = dt;
                    gvGroups.DataBind();
                }
            }
        }
    }

    private int GetSupervisoridId()
    {
        int supervisorID = 1;  // Default value to indicate not found
        string superisoremail = Session["SupervisorEmail"] as string;

        if (!string.IsNullOrEmpty(superisoremail))
        {
            // Replace with your actual database connection string and query
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT supervisor_id FROM Supervisors WHERE email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", superisoremail);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    supervisorID = Convert.ToInt32(result);
                }
            }
        }

        return supervisorID;
    }
}

