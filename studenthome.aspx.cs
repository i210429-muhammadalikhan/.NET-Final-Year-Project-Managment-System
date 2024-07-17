using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class studenthome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Assuming you retrieve the student email from the session or some other source


        string studentEmail = Session["StudentEmail"] as string;
        if (!string.IsNullOrEmpty(studentEmail))
        {
            PopulateStudentInfo(studentEmail);
        }
        else
        {
            // Handle case where student email is not available
        }
    }

    private void PopulateStudentInfo(string email)
    {
        // Retrieve student information from the database
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string query = "SELECT * FROM Students WHERE email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblStudentID.Text = reader["student_id"].ToString();
                    lblFullName.Text = reader["full_name"].ToString();
                    lblEmail.Text = reader["email"].ToString();
                    lblPhone.Text = reader["phone"].ToString();
                    lblDepartment.Text = reader["department"].ToString();
                }
                else
                {
                    // Student not found
                    // Handle error or redirect
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }
    }

    protected void btnUpdatedProfile_Click(object sender, EventArgs e)
    {

        Response.Redirect("UpdateStudentProfile.aspx");
    }

    protected void btnStudentGroupCreation_Click(object sender, EventArgs e)
    {
        Response.Redirect("studentgroupcreation.aspx");
    }

    protected void btnSupervisorAssignment_Click(object sender, EventArgs e)
    {
        Response.Redirect("supervisorassignmenttostudent.aspx");
    }

    protected void btnGroupMemberManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("GroupMemberManagement.aspx");
    }

    protected void btnProjectTitleDescription_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectTitleandDescriptionManagement.aspx");
    }

    protected void btnFeedbackBySupervisor_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeedbackBySupervisor.aspx");
    }

    protected void btnViewProjectDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewingProjectDetail.aspx");
    }

    protected void btnViewAssignedPanels_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAssignedPanel.aspx");
    }

    protected void btnEvaluationBySupervisor_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEvaluationByPanel.aspx");
    }

    protected void btnDeadlinesForSubmissions_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewSubmissions.aspx");
    }

    protected void btnViewGradesOfFYPs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewYourGradeOfFYP.aspx");
    }

    protected void btnSearchSpecificProjects_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchProjects.aspx");
    }

    protected void btnViewGroupInfo(object sender, EventArgs e)
    {
        Response.Redirect("viewgroup.aspx");
    }
    protected void btnViewSupervisorInfo(object sender, EventArgs e)
    {
        Response.Redirect("ViewSupervisorInfo.aspx"); 
    }

}
