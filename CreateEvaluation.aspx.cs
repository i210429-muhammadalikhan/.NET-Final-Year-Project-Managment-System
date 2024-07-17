using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class CreateEvaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindQuestions();
        }
    }

    protected void btnCreateQuestion_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Evaluation (QuestionDescription, TotalMarks) VALUES (@QuestionDescription, @TotalMarks)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@QuestionDescription", txtQuestionDescription.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
                cmd.ExecuteNonQuery();
            }
        }
        BindQuestions();
        txtQuestionDescription.Text = "";
        txtTotalMarks.Text = "";
    }

    private void BindQuestions()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Evaluation";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvQuestions.DataSource = dt;
                    gvQuestions.DataBind();
                }
            }
        }
    }
}