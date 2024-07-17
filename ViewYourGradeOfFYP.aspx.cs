using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Data;

public partial class ViewYourGradeOfFYP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEvaluation();
        }
    }

    private void BindEvaluation()
    {
        string leaderEmail = Session["StudentEmail"] as string;
        int groupID = GetGroupIDByStudentEmail(leaderEmail); // Replace with the actual group ID
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM GroupEvaluation WHERE GroupID = @GroupID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvEvaluation.DataSource = dt;
                    gvEvaluation.DataBind();
                    lblTotalMarks.Text = "Total Marks: " + dt.Compute("SUM(MarksObtained)", "").ToString();
                    CalculateGrade(dt);
                }
            }
        }
    }

    private void CalculateGrade(DataTable dt)
    {
        int totalMarks = int.Parse(lblTotalMarks.Text.Split(':')[1].Trim());
        if (totalMarks >= 90)
        {
            lblGrade.Text = "Grade: A";
        }
        else if (totalMarks >= 80)
        {
            lblGrade.Text = "Grade: B+";
        }
        else if (totalMarks >= 70)
        {
            lblGrade.Text = "Grade: B";
        }
        else if (totalMarks >= 60)
        {
            lblGrade.Text = "Grade: B-";
        }
        else if (totalMarks >= 50)
        {
            lblGrade.Text = "Grade: C+";
        }
        else if (totalMarks >= 40)
        {
            lblGrade.Text = "Grade: D";
        }
       
        else
        {
            lblGrade.Text = "Grade: F";
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.Add(new Paragraph("FYP Grade Report"));
            document.Add(new Paragraph("Group ID: 682")); // Replace with the actual group ID
            document.Add(new Paragraph("Evaluation Date: " + DateTime.Now.ToString()));
            document.Add(new Paragraph("Remarks: ")); // Add remarks if needed
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph("Evaluation Details:"));
            PdfPTable table = new PdfPTable(gvEvaluation.Columns.Count);
            for (int i = 0; i < gvEvaluation.Columns.Count; i++)
            {
                table.AddCell(gvEvaluation.Columns[i].HeaderText);
            }
            for (int i = 0; i < gvEvaluation.Rows.Count; i++)
            {
                for (int j = 0; j < gvEvaluation.Columns.Count; j++)
                {
                    table.AddCell(gvEvaluation.Rows[i].Cells[j].Text);
                }
                document.Add(table);
                document.Add(new Paragraph("Total Marks: " + lblTotalMarks.Text.Split(':')[1].Trim()));
                document.Add(new Paragraph("Grade: " + lblGrade.Text.Split(':')[1].Trim()));
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=FYPGradeReport.pdf");
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }
    }

    public int GetGroupIDByStudentEmail(string studentEmail)
    {
        int groupID = -1; // Default value if the student is not found in any group

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Query to find if the student is a group leader
        string queryLeader = "SELECT group_id FROM Groups WHERE group_leader_id IN (SELECT student_id FROM Students WHERE email = @StudentEmail)";

        // Query to find if the student is a group member
        string queryMember = "SELECT group_id FROM Group_Members WHERE student_id IN (SELECT student_id FROM Students WHERE email = @StudentEmail)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Check if the student is a group leader
            using (SqlCommand command = new SqlCommand(queryLeader, connection))
            {
                command.Parameters.AddWithValue("@StudentEmail", studentEmail);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // Student is a group leader
                        groupID = Convert.ToInt32(result);
                        return groupID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // Check if the student is a group member
            using (SqlCommand command = new SqlCommand(queryMember, connection))
            {
                command.Parameters.AddWithValue("@StudentEmail", studentEmail);
                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // Student is a group member
                        groupID = Convert.ToInt32(result);
                        return groupID;
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