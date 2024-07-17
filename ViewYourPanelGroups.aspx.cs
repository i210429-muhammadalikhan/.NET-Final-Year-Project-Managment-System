using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewYourPanelGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroups();
        }
    }

    private void BindGroups()
    {
        int xpenalid = GetPanelIDForPanelMember();
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT g.group_id, g.group_name, g.project_title FROM Groups g INNER JOIN PanelGroupAssignment pga ON g.group_id = pga.group_id WHERE pga.panel_id = @penalid";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@penalid", xpenalid);

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


    public int GetPanelIDForPanelMember()
    {
        int panelMemberID = GetPanelMemberID();
        int panelID = -1; // Default value in case no panel ID is found

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        string query = "SELECT TOP 1 panel_id FROM Panel_PanelMembers WHERE panel_member_id = @PanelMemberID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PanelMemberID", panelMemberID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        panelID = Convert.ToInt32(reader["panel_id"]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return panelID;
    }


    private int GetPanelMemberID()
    {
        int supervisorID = 1;  // Default value to indicate not found
        string superisoremail = Session["PenalMemberEmail"] as string;

        if (!string.IsNullOrEmpty(superisoremail))
        {
            // Replace with your actual database connection string and query
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT panel_member_id  FROM PanelMembers  WHERE email = @Email";

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