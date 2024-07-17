using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class studentgroupcreation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStudentsGrid();
        }
    }

    private void BindStudentsGrid()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = @"SELECT student_id, full_name, email, department 
                         FROM Students 
                         WHERE student_id NOT IN (SELECT student_id FROM Group_Members)
                         AND student_id NOT IN (SELECT group_leader_id FROM Groups)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvStudents.DataSource = dt;
                    gvStudents.DataBind();
                }
            }
        }
    }


    protected void btnCreateGroup_Click(object sender, EventArgs e)
    {
        try
        {
            string groupname = groupName.Text.Trim();  // Corrected variable name
            string projectTitle = projectName.Text.Trim();


            

            if (groupname.Length <= 255 && projectTitle.Length <= 255)
            {
                // Both group name and project title lengths are within the acceptable boundary
                // Proceed with your logic here

                // For example, you can proceed with saving the data to a database or performing further operations
            }
            else
            {
                // Either group name or project title length exceeds the acceptable boundary
                // Handle the error, perhaps by showing an error message to the user
                // For example, you can show a message indicating the maximum length allowed
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Group Name and Project Title must be maximum 255 characters long.');", true);
            }






            int leaderId = GetLeaderId();
            int groupId = GenerateGroupId();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Groups (group_id, group_name, project_title, group_leader_id) VALUES (@GroupId, @GroupName, @ProjectTitle, @LeaderId)", con, transaction);
                        cmd.Parameters.AddWithValue("@GroupId", groupId);
                        cmd.Parameters.AddWithValue("@GroupName", groupname);
                        cmd.Parameters.AddWithValue("@ProjectTitle", projectTitle);
                        cmd.Parameters.AddWithValue("@LeaderId", leaderId);
                        cmd.ExecuteNonQuery();

                        foreach (GridViewRow row in gvStudents.Rows)
                        {
                            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                            if (chk != null && chk.Checked)
                            {
                                int studentId = Convert.ToInt32(gvStudents.DataKeys[row.RowIndex].Value);
                                SqlCommand cmdMember = new SqlCommand("INSERT INTO Group_Members (group_id, student_id) VALUES (@GroupId, @StudentId)", con, transaction);
                                cmdMember.Parameters.AddWithValue("@GroupId", groupId);
                                cmdMember.Parameters.AddWithValue("@StudentId", studentId);
                                cmdMember.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        lblErrorMessage.Text = "Group created successfully!";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblErrorMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = "Error: Unable to connect to database - " + ex.Message;
        }
    }




    private int GenerateGroupId()
    {
        Random random = new Random();
        int groupId = random.Next(100, 999); // Generates a random number between 10000 and 99999
        return groupId;
    }

    private int GetLeaderId()
    {
        int leaderId = 1;  // Default value to indicate not found
        string leaderEmail =  Session["StudentEmail"] as string;
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
