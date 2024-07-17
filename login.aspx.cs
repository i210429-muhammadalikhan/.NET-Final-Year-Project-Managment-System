using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

       // username.text
        // You can handle any initialization logic here
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {

        string Username = username.Value; // Retrieve username from username input field
        string Password = password.Value; // Retrieve password from password input field
        string UserRole = userRole.Value; // Retrieve selected role from dropdown list


      
        if (Username.Contains("@") && Password.Length >= 6 && !string.IsNullOrEmpty(UserRole))
        {
            // Valid credentials
            // Proceed with your logic here

            // For example, showing a success message
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login successful!');", true);
        }
        else
        {
            // Invalid credentials
            // Show a popup message indicating the error
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid credentials. Please check your inputs.');", true);
        }





        Session["StudentEmail"] = Username;
        Session["SupervisorEmail"] = Username;


        // Perform authentication based on the selected role
        bool isAuthenticated = false;

        switch (UserRole)
        {
            case "1":
                isAuthenticated = AuthenticateAdmin(Username, Password);
                if (isAuthenticated)
                {
                    Session["AdminEmail"] = Username;
                    // Redirect the user to a dashboard or home page
                    Response.Redirect("Adminhome.aspx");
                }


                break;
            case "2":
                isAuthenticated = AuthenticateStudent(Username, Password);

                if (isAuthenticated)
                {
                    Session["StudentEmail"] = Username;
                    // Redirect the user to a dashboard or home page
                    InsertLoginAudit(Username, "Student", "Logging In");
                    Response.Redirect("studenthome.aspx");
                }

                break;
            case "3":
                isAuthenticated = AuthenticateFYPCommitteeMember(Username, Password);

                if (isAuthenticated)
                {
                    Session["FYPmemberEmail"] = Username;
                    // Redirect the user to a dashboard or home page
                    Response.Redirect("FYPCommitteeHomeScreen.aspx");
                }

                break;
            case "4":
                isAuthenticated = AuthenticateSupervisor(Username, Password);

                if (isAuthenticated)
                {
                    Session["SupervisorEmail"] = Username;
                    // Redirect the user to a dashboard or home page
                    Response.Redirect("SuperVisorHomeScreen.aspx");
                }

                break;
            case "5":
                isAuthenticated = AuthenticatePanelMember(Username, Password);

                if (isAuthenticated)
                {
                    Session["PenalMemberEmail"] = Username;
                    // Redirect the user to a dashboard or home page
                    Response.Redirect("PanelHomeScreen.aspx");
                }


                break;
            default:
                break;
        }

        // Handle authentication result
        if (isAuthenticated)
        {
            // Redirect the user to a dashboard or home page
            Response.Redirect("studenthome.aspx");
        }
        else
        {
            // If authentication fails, display an error message
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = "Invalid username or password for the selected role.";
        }
    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {


        Response.Redirect("signup.aspx");


    }

    // Authentication methods for each role
    private bool AuthenticateAdmin(string username, string password)
    {
        // Authentication logic for Admin role
        // Replace this with your actual authentication logic
        return (username == "admin@example.com" && password == "adminpassword");
    }

    private bool AuthenticateStudent(string username, string password)
    {
        // Connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to check if the provided username and password match any student record
        string query = "SELECT COUNT(*) FROM Students WHERE email = @username AND password = @password";

        // Create connection and command objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the command and get the result
                int count = (int)command.ExecuteScalar();

                // If count > 0, the user is authenticated
                return count > 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection error)
                // You can log the exception or display an error message
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "An error occurred while authenticating. Please try again later.";
                return false;
            }
        }
    }

    private bool AuthenticateFYPCommitteeMember(string username, string password)
    {
        // Connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to check if the provided username and password match any student record
        string query = "SELECT COUNT(*) FROM FYPCommitteeMembers WHERE email = @username AND password = @password";

        // Create connection and command objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the command and get the result
                int count = (int)command.ExecuteScalar();

                // If count > 0, the user is authenticated
                return count > 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection error)
                // You can log the exception or display an error message
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "An error occurred while authenticating. Please try again later.";
                return false;
            }
        }
    }

    private bool AuthenticateSupervisor(string username, string password)
    { // Connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to check if the provided username and password match any student record
        string query = "SELECT COUNT(*) FROM Supervisors WHERE email = @username AND password = @password";

        // Create connection and command objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the command and get the result
                int count = (int)command.ExecuteScalar();

                // If count > 0, the user is authenticated
                return count > 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection error)
                // You can log the exception or display an error message
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "An error occurred while authenticating. Please try again later.";
                return false;
            }
        }
    }

    private bool AuthenticatePanelMember(string username, string password)
    {

        // Connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to check if the provided username and password match any student record
        string query = "SELECT COUNT(*) FROM PanelMembers WHERE email = @username AND password = @password";

        // Create connection and command objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the command and get the result
                int count = (int)command.ExecuteScalar();

                // If count > 0, the user is authenticated
                return count > 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection error)
                // You can log the exception or display an error message
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "An error occurred while authenticating. Please try again later.";
                return false;
            }
        }

    }


    public void InsertLoginAudit(string userEmail, string userRole, string action)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO UserLoginAudit (UserEmail, UserRole, Action, LoginTime) " +
                           "VALUES (@UserEmail, @UserRole, @Action, @LoginTime)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserEmail", userEmail);
            command.Parameters.AddWithValue("@UserRole", userRole);
            command.Parameters.AddWithValue("@Action", action);
            command.Parameters.AddWithValue("@LoginTime", DateTime.Now);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting login audit: " + ex.Message);
                // You can handle the exception as per your application's requirements.
            }
        }
    }

}