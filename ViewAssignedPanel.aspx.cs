using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewAssignedPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPanelMembers();
        }
    }

    private void BindPanelMembers()
    {
        string leaderEmail = Session["StudentEmail"] as string;

        int groupId = GetGroupIDByStudentEmail(leaderEmail); // Replace with the actual group ID
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT pm.full_name, pm.email, pm.phone, pm.registration_id, pm.department FROM PanelMembers pm INNER JOIN Panel_PanelMembers ppm ON pm.panel_member_id = ppm.panel_member_id INNER JOIN PanelGroupAssignment pga ON ppm.panel_id = pga.panel_id WHERE pga.group_id = @group_id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@group_id", groupId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvPanelMembers.DataSource = dt;
                    gvPanelMembers.DataBind();
                }
            }
        }
    }

    public int GetGroupIDByStudentEmail(string studentEmail)
    {
        int groupID = -1; // Default value if the student is not found in any group

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to find if the student is a group leader
        string queryLeader = "SELECT group_id FROM Groups WHERE group_leader_id IN (SELECT student_id FROM Students WHERE email = @StudentEmail)";

        // Query to find if the student is a group member
        string queryMember = "SELECT group_id FROM Group_Members WHERE student_id IN (SELECT student_id FROM Students WHERE email = @StudentEmail)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Check if the student is a group leader
            using (SqlCommand command = new SqlCommand(queryLeader, connection))
            {
                command.Parameters.AddWithValue("@StudentEmail", studentEmail);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // Student is a group leader
                        groupID = Convert.ToInt32(result);
                        return groupID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // Check if the student is a group member
            using (SqlCommand command = new SqlCommand(queryMember, connection))
            {
                command.Parameters.AddWithValue("@StudentEmail", studentEmail);
                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // Student is a group member
                        groupID = Convert.ToInt32(result);
                        return groupID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return groupID;
    }
}