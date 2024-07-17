using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewYourPanelProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProjectInfo();
        }
    }

    private void BindProjectInfo()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT p.project_id, p.project_description, p.leader_ID, p.leader_name, p.project_title, g.group_id, g.group_name, g.group_leader_id FROM Project p JOIN Groups g ON p.leader_ID = g.group_leader_id JOIN PanelGroupAssignment pga ON g.group_id = pga.group_id WHERE pga.panel_id = @panel_id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@panel_id", GetPanelIDForPanelMember()); // replace x with the actual panel ID
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvProjectInfo.DataSource = dt;
                    gvProjectInfo.DataBind();
                }
            }
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Button btnSelect = (Button)sender;
        int selectedGroupId = int.Parse(btnSelect.CommandArgument);
        bool x = IsGroupIdExists(selectedGroupId);

        if (x) {
            Response.Redirect("PanelHomeScreen.aspx");

        }


        Session["SelectedGroupId"] = selectedGroupId;
        Response.Redirect("EvaluationPage.aspx");
    }

    public bool IsGroupIdExists(int selectedGroupId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        bool exists = false;

        string query = "SELECT COUNT(*) FROM GroupEvaluation WHERE GroupID = @SelectedGroupId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SelectedGroupId", selectedGroupId);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, the selectedGroupId exists in the GroupEvaluation table
                    exists = count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return exists;
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