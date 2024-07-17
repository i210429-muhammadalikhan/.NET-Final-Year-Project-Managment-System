using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class ViewStudentGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int supervisorId = GetSupervisoridId(); // Replace X with the actual supervisor ID
            List<GroupProjectInfo> groupProjectData = GetGroupProjectInfo(supervisorId);

            gvGroupsProjects.DataSource = groupProjectData;
            gvGroupsProjects.DataBind();
        }
    }

    private List<GroupProjectInfo> GetGroupProjectInfo(int supervisorId)
    {
        // Replace with your actual database connection string and query
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = @"
            SELECT g.group_name, p.project_title, gs.leader_name
            FROM GroupSuperVisor gs
            INNER JOIN Project p ON gs.projectid = p.project_id
            INNER JOIN Groups g ON p.project_title = g.project_title 
            WHERE gs.supervisorid = @SupervisorId";

        List<GroupProjectInfo> groupProjectList = new List<GroupProjectInfo>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupervisorId", supervisorId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                GroupProjectInfo info = new GroupProjectInfo();
                info.GroupName = reader["group_name"].ToString();
                info.ProjectTitle = reader["project_title"].ToString();
                info.LeaderName = reader["leader_name"].ToString();
                groupProjectList.Add(info);
            }
        }

        return groupProjectList;
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

// Class to hold group and project information
public class GroupProjectInfo
{
    public string GroupName { get; set; }
    public string ProjectTitle { get; set; }
    public string LeaderName { get; set; }
}