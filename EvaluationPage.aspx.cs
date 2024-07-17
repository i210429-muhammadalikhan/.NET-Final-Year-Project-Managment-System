using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class EvaluationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEvaluationQuestions();
        }
    }

    private void BindEvaluationQuestions()
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
                    gvEvaluation.DataSource = dt;
                    gvEvaluation.DataBind();
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        int groupId = (int)Session["SelectedGroupId"];

        // Replace with the actual group ID
        foreach (GridViewRow row in gvEvaluation.Rows)
        {
            int questionId = int.Parse(row.Cells[0].Text);
            string questionDescription = row.Cells[1].Text;
            int totalMarks = int.Parse(row.Cells[2].Text);
            TextBox txtMarksObtained = (TextBox)row.FindControl("txtMarksObtained");
            int marksObtained = int.Parse(txtMarksObtained.Text);
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
            string remarks = txtRemarks.Text;



            if (marksObtained >= 0 && marksObtained <= 10 && remarks.Length <= 255)
            {
                
            }
            else
            {
                // Handle the error, perhaps by showing an error message to the user
                // For example, you can show a message indicating the allowed range for marks obtained and the maximum length for remarks
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Marks obtained must be between 0 and 10, and remarks must be maximum 255 characters long.');", true);
            }










            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;






            // Insert into GroupEvaluation table
            string query = "INSERT INTO GroupEvaluation (GroupID, EvaluationDate, Remarks, QuestionID, MarksObtained) VALUES (@GroupID, @EvaluationDate, @Remarks, @QuestionID, @MarksObtained)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GroupID", groupId);
                    cmd.Parameters.AddWithValue("@EvaluationDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.Parameters.AddWithValue("@QuestionID", questionId);
                    cmd.Parameters.AddWithValue("@MarksObtained", marksObtained);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}