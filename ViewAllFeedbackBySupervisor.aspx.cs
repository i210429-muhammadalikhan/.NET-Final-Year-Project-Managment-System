using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class ViewAllFeedbackBySupervisor : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFeedbackData();
        }
    }

   

    private void BindFeedbackData()
    {
        // Connection string to your database
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // SQL query to fetch all feedback data
        string query = "SELECT FeedbackID, GroupID, AssignmentID, AssignmentDescription, FeedbackDate, FeedbackText FROM Feedback";

        // Create a connection and command objects
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Open connection and execute query
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the DataTable to the GridView
                GridViewFeedback.DataSource = dt;
                GridViewFeedback.DataBind();
            }
        }
    }

}
