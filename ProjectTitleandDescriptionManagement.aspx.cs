using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectTitleandDescriptionManagement : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the form was submitted
        if (IsPostBack)
        {
            // Check if the upload button was clicked
            if (Request.Form["btnUpload"] != null)
            {
                // Call the method to insert data into the database
                InsertDataIntoProjectTable();
            }
        }
    }

    private void InsertDataIntoProjectTable()
    {
      
    }


    protected void btnuploadProjectTitleDescription_Click(object sender, EventArgs e)
    {
        try
        {
          //  Get the values entered by the user
            string customProjectTitle = ProjectTitle.Text;
            string customLeaderName = GroupLeaderName.Text;
            int customLeaderID = Convert.ToInt32(GroupLeaderID.Text);
            string customProjectDescription = ProjectDescription.Text;



           

            if (customProjectTitle.Length <= 255 &&
                customLeaderName.Length <= 255 &&
                customLeaderID.ToString().Length <= 255 &&
                customProjectDescription.Length <= 255)
            {
                // All input lengths are within the acceptable boundary
                // Proceed with your logic here

                // For example, you can proceed with saving the data to a database or performing further operations
            }
            else
            {
                // Handle the error, perhaps by showing an error message to the user
                // For example, you can show a message indicating the maximum length allowed for each input
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Input fields must be maximum 255 characters long.');", true);
            }



            // Insert data into the database
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = @"INSERT INTO Project (project_description, leader_ID, leader_name, project_title) 
                             VALUES (@ProjectDescription, @LeaderID, @LeaderName, @ProjectTitle)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@ProjectDescription", customProjectDescription);
                    command.Parameters.AddWithValue("@LeaderID", GetLeaderId());
                    command.Parameters.AddWithValue("@LeaderName", customLeaderName);
                    command.Parameters.AddWithValue("@ProjectTitle", customProjectTitle);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Redirect("studenthome.aspx");
                        // Insert successful
                        Response.Write("<script>alert('Project details added successfully.');</script>");
                    }
                    else
                    {
                        Response.Redirect("studenthome.aspx");

                        // Insert failed
                        Response.Write("<script>alert('Failed to add project details.');</script>");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
        }
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
