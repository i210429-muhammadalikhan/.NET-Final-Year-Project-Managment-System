using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewgroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int gid = GetGroupIdByLeaderId(GetLeaderId());
            int lid = GetLeaderId();
            int[] memberIds = GetMemberIdsByGroupId(gid);


            BindStudentGrid(lid, memberIds);
        }
    }


    public int[] GetMemberIdsByGroupId(int groupId)
    {
        List<int> memberIds = new List<int>();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT student_id FROM Group_Members WHERE group_id = @GroupId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@GroupId", groupId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int memberId = Convert.ToInt32(reader["student_id"]);
                        memberIds.Add(memberId);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error retrieving member IDs: " + ex.Message);
                }
            }
        }

        return memberIds.ToArray();
    }
    private void BindStudentGrid(int lid, int[] studentIds)
    {
        // Create a parameterized SQL query
        string query = "SELECT * FROM Students WHERE student_id IN ({0})";

        // Create a list of parameters
        List<SqlParameter> parameters = new List<SqlParameter>();

        // Add the leader ID as a parameter
        parameters.Add(new SqlParameter("@id0", lid));

        // Add each student ID as a parameter
        for (int i = 0; i < studentIds.Length; i++)
        {
            parameters.Add(new SqlParameter("@id" + (i + 1), studentIds[i]));
        }

        // Join the parameter names into a string for the SQL query
        string parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));

        // Replace the {0} placeholder in the query with the parameter names
        query = string.Format(query, parameterNames);

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Add the parameters to the command
                cmd.Parameters.AddRange(parameters.ToArray());

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }


    public int GetGroupIdByLeaderId(int leaderId)
    {
        int groupId = -1; // Default value if no group is found

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT group_id FROM Groups WHERE group_leader_id = @LeaderId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LeaderId", leaderId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        groupId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error retrieving group ID: " + ex.Message);
                }
            }
        }

        return groupId;
    }


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
}
