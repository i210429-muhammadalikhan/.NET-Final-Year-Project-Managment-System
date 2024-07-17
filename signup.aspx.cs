using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        string firstname = firstName.Value;
        string lastname = lastName.Value;
        int regid = int.Parse(regID.Value);
        string Department = department.Value;
        string usernamee = username.Value;
        string phonenumberr = phonenumber.Value;
        string passwordd = password.Value;
        string confirmPasswordd = confirmPassword.Value;
        string userRolee = userRole.Value;

        // Checks
        if (!IsAlpha(firstname) || firstname.Length > 255)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = ".";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('First Name must be alphabetic and less than or equal to 255 characters.');", true);


            return;
        }

        if (!IsAlpha(lastname) || lastname.Length > 255)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = "Last Name must be alphabetic and less than or equal to 255 characters.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Last Name must be alphabetic and less than or equal to 255 characters.');", true);


            return;
        }

       

        if ((phonenumberr.Length > 255) || (!IsNumeric(phonenumberr)))
        {
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = "Phone number must be numeric and less than or equal to 255 characters.";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Phone number must be numeric and less than or equal to 255 characters.');", true);

            return;
        }

        if (passwordd.Length < 8)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = "Password must be at least 8 characters long.";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password must be at least 8 characters long');", true);

            return;
        }

        if (passwordd != confirmPasswordd)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.InnerText = "Passwords do not match.";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Passwords do not match.');", true);


            return;
        }

        // Insert into database

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string query = "INSERT INTO Students (student_id ,full_name, email, password, phone, department, registration_date) VALUES (@regid,@full_name, @email, @password, @phone, @department, @registration_date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
            command.Parameters.AddWithValue("@regid", regid.ToString());
                command.Parameters.AddWithValue("@full_name", firstname.ToString() + " " + lastname.ToString());
                command.Parameters.AddWithValue("@email", usernamee.ToString());
                command.Parameters.AddWithValue("@password", passwordd.ToString());
                command.Parameters.AddWithValue("@phone", phonenumberr.ToString());
                command.Parameters.AddWithValue("@department", Department.ToString());
                command.Parameters.AddWithValue("@registration_date", DateTime.Now);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ErrorMessage.Visible = true;
                    ErrorMessage.InnerText = "Sign up successful!";

                Response.Redirect("login.aspx");


            }
            catch (Exception ex)
                {
                    ErrorMessage.Visible = true;
                    ErrorMessage.InnerText = "An error occurred while signing up. Please try again later.";
                }
            }
        }
        private bool IsAlpha(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsNumeric(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

}