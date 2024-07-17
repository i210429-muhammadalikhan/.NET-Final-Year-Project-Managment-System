using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class GroupMemberManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroupMembers();
        }
    }

    private void BindGroupMembers()
    {
        

        int groupLeaderID = GetStudentIDByEmail();
        int groupID = 0;

        if(IsStudentGroupLeader(groupLeaderID) ) {
        groupID= GetGroupIDByStudentID(groupLeaderID);


        } 
        else {

            Response.Redirect("studenthome.aspx");
        }
        
        
        // get the current group leader's ID
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT s.student_id, s.full_name, s.email FROM Students s INNER JOIN Group_Members gm ON s.student_id = gm.student_id WHERE gm.group_id = @group_id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@group_id", groupID); // get the current group ID);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvMembers.DataSource = dt;
                    gvMembers.DataBind();
                }
            }
        }
    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        int studentID = int.Parse(txtAddMember.Text);



        int groupLeaderID = GetStudentIDByEmail();
        int groupID = GetGroupIDByStudentID(groupLeaderID);


           // int groupID = 0;// get the current group ID
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Group_Members (group_id, student_id) VALUES (@group_id, @student_id)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@group_id", groupID);
                cmd.Parameters.AddWithValue("@student_id", studentID);
                cmd.ExecuteNonQuery();
                BindGroupMembers();
            }
        }
    }

    protected void btnRemoveMember_Click(object sender, EventArgs e)
    {
        int studentID = int.Parse(txtRemoveMember.Text);
        //int groupID = 0;// get the current group ID

        int groupLeaderID = GetStudentIDByEmail();
        int groupID = GetGroupIDByStudentID(groupLeaderID);

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Group_Members WHERE group_id = @group_id AND student_id = @student_id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@group_id", groupID);
                cmd.Parameters.AddWithValue("@student_id", studentID);
                cmd.ExecuteNonQuery();
                BindGroupMembers();
            }
        }
    }


    public int GetStudentIDByEmail()
    {
        string email = Session["StudentEmail"] as string;

        int studentID = -1; // Default value if the student is not found

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        string query = "SELECT student_id FROM Students WHERE email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        studentID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return studentID;
    }


    public bool IsStudentGroupLeader(int studentID)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        bool isLeader = false;

        string query = "SELECT COUNT(*) FROM Groups WHERE group_leader_id = @StudentID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isLeader = count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return isLeader;
    }


    public int GetGroupIDByStudentID(int studentID)
    {
        int groupID = -1; // Default value if the student is not a member of any group

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        string query = "SELECT group_id FROM Groups WHERE group_leader_id = @StudentID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        groupID = Convert.ToInt32(result);
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