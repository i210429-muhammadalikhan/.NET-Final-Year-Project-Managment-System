using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class ViewSupervisorInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get supervisor ID (replace X with the actual ID or retrieval logic)
            int x = GetLeaderId();
            int supervisorId = GetSupervisorIdByLeaderId(x); // Replace X with the actual supervisor ID
            
            Supervisor supervisor = GetSupervisorInfo(supervisorId);

            if (supervisor != null)
            {
                lblFullName.Text = supervisor.FullName;
                lblEmail.Text = supervisor.Email;
                lblPhone.Text = supervisor.Phone;
                lblRegistrationId.Text = supervisor.RegistrationId;
                lblDepartment.Text = supervisor.Department;
            }
            else
            {
                // Handle case where supervisor is not found
                // (e.g., display a message or redirect)
            }
        }
    }

    private Supervisor GetSupervisorInfo(int supervisorId)
    {
        // Replace with your actual database connection string and query
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT * FROM Supervisors WHERE supervisor_id = @SupervisorId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupervisorId", supervisorId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Supervisor supervisor = new Supervisor();
                supervisor.FullName = reader["full_name"].ToString();
                supervisor.Email = reader["email"].ToString();
                supervisor.Phone = reader["phone"].ToString();
                supervisor.RegistrationId = reader["registration_id"].ToString();
                supervisor.Department = reader["department"].ToString();
                return supervisor;
            }
        }

        return null; // Supervisor not found
    }

    public int GetSupervisorIdByLeaderId(int leaderId)
    {
        // Replace with your actual database connection string and query
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT supervisorid FROM GroupSuperVisor WHERE leader_id = @LeaderId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LeaderId", leaderId);

            connection.Open();
            object result = command.ExecuteScalar(); // Get the first column of the first row

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
        }

        return 0; // Supervisor not found
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

// Supervisor class to hold supervisor data
public class Supervisor
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string RegistrationId { get; set; }
    public string Department { get; set; }
}