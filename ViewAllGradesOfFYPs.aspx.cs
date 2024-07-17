using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewAllGradesOfFYPs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadGroupGrades();
    }

    private void LoadGroupGrades()
    {
        // Connect to database
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        // Create a command to retrieve data
        SqlCommand command = new SqlCommand("SELECT \r\n    ge.GroupID, \r\n    SUM(ge.MarksObtained) AS TotalMarksObtained, \r\n    CASE \r\n        WHEN SUM(ge.MarksObtained) >= 80 THEN 'A' \r\n        WHEN SUM(ge.MarksObtained) >= 70 THEN 'B' \r\n        WHEN SUM(ge.MarksObtained) >= 50 THEN 'C' \r\n        ELSE 'F' \r\n    END AS Grade \r\nFROM \r\n    GroupEvaluation ge \r\nINNER JOIN \r\n    Evaluation e ON ge.QuestionID = e.QuestionID \r\nGROUP BY \r\n    ge.GroupID", connection);

        // Execute the command and load data into a DataTable
        DataTable dataTable = new DataTable();
        dataTable.Load(command.ExecuteReader());

        // Bind data to GridView
        GridView1.DataSource = dataTable;
        GridView1.DataBind();

        // Close the connection
        connection.Close();
    }
}