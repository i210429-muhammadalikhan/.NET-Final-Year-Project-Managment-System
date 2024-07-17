using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class PanelGroupAssign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroups();
            BindPanels();
        }
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        // Code to assign panel to group goes here
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO PanelGroupAssignment (panel_id, group_id) VALUES (@panel_id, @group_id)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@panel_id", ddlPanels.SelectedValue);
                cmd.Parameters.AddWithValue("@group_id", ddlGroups.SelectedValue);
                cmd.ExecuteNonQuery();
            }
        }
    }

    private void BindGroups()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT *\r\nFROM Groups\r\nLEFT JOIN PanelGroupAssignment ON Groups.group_id = PanelGroupAssignment.group_id\r\nWHERE PanelGroupAssignment.group_id IS NULL;";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlGroups.DataSource = dt;
                    ddlGroups.DataTextField = "group_name";
                    ddlGroups.DataValueField = "group_id";
                    ddlGroups.DataBind();
                }
            }
        }
    }

    private void BindPanels()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT DISTINCT panel_id FROM Panel_PanelMembers;";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlPanels.DataSource = dt;
                    ddlPanels.DataValueField = "panel_id";
                    ddlPanels.DataBind();
                }
            }
        }
    }
}