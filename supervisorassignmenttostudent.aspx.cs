using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class supervisorassignmenttostudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateSupervisorsDropdown();
        }
    }

    private void PopulateSupervisorsDropdown()
    {
        // Replace connection string with your actual connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT supervisor_id, full_name, department FROM Supervisors";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            ddlSupervisors.DataSource = command.ExecuteReader();
            ddlSupervisors.DataBind();
            ddlSupervisors.Items.Insert(0, new ListItem("-- Select Supervisor --", ""));
        }
    }

    protected void btnAssignSupervisor_Click(object sender, EventArgs e)
    {
        if (ddlSupervisors.SelectedValue != "")
        {
            int supervisorId = Convert.ToInt32(ddlSupervisors.SelectedValue);
            string supervisorName = ddlSupervisors.SelectedItem.Text;

            // Get leader ID, project ID, and leader name (assuming you have access to this information)
            int leaderId = GetLeaderId(); // Replace with actual leader ID
            int projectId = GetProjectIdByLeaderId(leaderId); // Replace with actual project ID
            string leaderName = GetLeaderNameByLeaderId(leaderId); // Replace with actual leader name

            // Insert data into GroupSupervisor table
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string insertQuery = "INSERT INTO GroupSuperVisor (supervisorid, supervisor_name, projectid, leader_id, leader_name) VALUES (@supervisorId, @supervisorName, @projectId, @leaderId, @leaderName)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@supervisorId", supervisorId);
                command.Parameters.AddWithValue("@supervisorName", supervisorName);
                command.Parameters.AddWithValue("@projectId", projectId);
                command.Parameters.AddWithValue("@leaderId", leaderId);
                command.Parameters.AddWithValue("@leaderName", leaderName);
                connection.Open();
                command.ExecuteNonQuery();
            }
            lblMessage.Text = "Supervisor assigned successfully!";
        }
        else
        {
            lblMessage.Text = "Please select a supervisor.";
        }
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


    public int GetProjectIdByLeaderId(int leaderId)
    {
        int projectId = -1; // Default value to indicate no project found

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT project_id FROM Project WHERE leader_ID = @leaderId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@leaderId", leaderId);
            connection.Open();

            object result = command.ExecuteScalar();
            if (result != null)
            {
                projectId = Convert.ToInt32(result);
            }
        }

        return projectId;
    }

    public string GetLeaderNameByLeaderId(int leaderId)
    {
        string leaderName = ""; // Initialize leaderName as an empty string

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT leader_name FROM Project WHERE leader_ID = @leaderId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@leaderId", leaderId);
            connection.Open();

            object result = command.ExecuteScalar();
            if (result != null)
            {
                leaderName = result.ToString();
            }
        }

        return leaderName;
    }
}