using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ViewingProjectDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int leaderId = GetLeaderId(); // Replace with your actual function to get leader ID
            DisplayProjectDetails(leaderId);
        }
    }

    // Replace this with your actual function to retrieve the leader ID
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

    private void DisplayProjectDetails(int leaderId)
    {
        // Replace with your actual connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            string query = "SELECT * FROM Project WHERE leader_ID = @LeaderId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@LeaderId", leaderId);

            DataTable dtProjects = new DataTable();
            adapter.Fill(dtProjects);

            gvProjects.DataSource = dtProjects;
            gvProjects.DataBind();
        }
    }
}