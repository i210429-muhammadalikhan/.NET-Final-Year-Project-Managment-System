using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewYourPanel : System.Web.UI.Page
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
        int memberid = GetPanelMemberID();
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT pm.panel_member_id, pm.full_name, pm.email, pm.phone, pm.registration_id, pm.department FROM PanelMembers pm INNER JOIN Panel_PanelMembers ppm ON pm.panel_member_id = ppm.panel_member_id WHERE ppm.panel_id IN (SELECT panel_id FROM Panel_PanelMembers WHERE panel_member_id = @memberid)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@memberid", memberid);

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

    private int GetPanelMemberID( )
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