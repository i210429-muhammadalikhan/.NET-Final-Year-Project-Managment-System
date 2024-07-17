using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class VeiwProjectAssigned : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int supervisorid = GetSupervisoridId(); // Replace with the actual supervisor ID
        BindProjects(supervisorid);
    }

    private void BindProjects(int supervisorid)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT p.project_title, p.project_description, gs.leader_name FROM GroupSuperVisor gs INNER JOIN Project p ON gs.projectid = p.project_id WHERE gs.supervisorid = @supervisorid";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@supervisorid", supervisorid);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvProjects.DataSource = dt;
                    gvProjects.DataBind();
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