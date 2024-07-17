using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class PanelCreationByFYPCommittee : System.Web.UI.Page
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
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM PanelMembers WHERE panel_member_id NOT IN (SELECT panel_member_id FROM Panel_PanelMembers);";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
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

    protected void ddlPanels_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPanels = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlPanels.NamingContainer;

        if (row != null && gvPanelMembers.Rows.Count > 0 && row.RowIndex < gvPanelMembers.Rows.Count)
        {
            int panelMemberID = Convert.ToInt32(gvPanelMembers.DataKeys[row.RowIndex].Value);
            string panelName = ddlPanels.SelectedValue;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Panel_PanelMembers (panel_id, panel_member_id) VALUES (@panel_id, @panel_member_id)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@panel_id", GetPanelID(panelName));
                    cmd.Parameters.AddWithValue("@panel_member_id", panelMemberID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        else
        {
            // Handle the case when the row index is out of range or the GridView has no rows.
        }
    }

    private int GetPanelID(string panelName)
    {
        int panelID = 0; // Default value if panelName is not found

        switch (panelName)
        {
            case "Panel1":
                panelID = 1; // Assuming panelID for Panel1 is 1
                break;
            case "Panel2":
                panelID = 2; // Assuming panelID for Panel2 is 2
                break;
            case "Panel3":
                panelID = 3; // Assuming panelID for Panel3 is 3
                break;
            case "Panel4":
                panelID = 4; // Assuming panelID for Panel4 is 4
                break;
            case "Panel5":
                panelID = 5; // Assuming panelID for Panel5 is 5
                break;
            case "Panel6":
                panelID = 6; // Assuming panelID for Panel6 is 6
                break;
            case "Panel7":
                panelID = 7; // Assuming panelID for Panel7 is 7
                break;
            case "Panel8":
                panelID = 8; // Assuming panelID for Panel8 is 8
                break;
            default:
                // Handle the case when the panelName is not recognized
                break;
        }

        return panelID;
    }

}