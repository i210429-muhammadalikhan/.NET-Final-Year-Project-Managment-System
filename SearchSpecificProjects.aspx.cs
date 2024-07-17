using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SearchSpecificProjects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchType = "";
        if (rbProjectID.Checked)
        {
            searchType = "project_id";
        }
        else if (rbProjectTitle.Checked)
        {
            searchType = "project_title";
        }
        else if (rbDepartment.Checked)
        {
            searchType = "department";
        }
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT p.project_id, p.project_title, s.full_name as leader_name, s.department " +
                           "FROM Project p INNER JOIN Students s ON p.leader_ID = s.student_id " +
                           "WHERE " + searchType + " LIKE @searchTerm";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchTerm", "%" + txtSearch.Text + "%");
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
}