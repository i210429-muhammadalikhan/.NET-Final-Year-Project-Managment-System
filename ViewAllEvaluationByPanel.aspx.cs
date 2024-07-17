using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class ViewAllEvaluationByPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT ge.GroupID, ge.EvaluationDate, ge.Remarks, e.QuestionDescription, ge.MarksObtained, e.TotalMarks " +
                           "FROM GroupEvaluation ge " +
                           "INNER JOIN Evaluation e ON ge.QuestionID = e.QuestionID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvEvaluations.DataSource = dt;
                    gvEvaluations.DataBind();
                }
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.Add(new Paragraph("Evaluations of Groups"));
            PdfPTable table = new PdfPTable(gvEvaluations.Columns.Count);
            for (int i = 0; i < gvEvaluations.Columns.Count; i++)
            {
                table.AddCell(gvEvaluations.Columns[i].HeaderText);
            }
            for (int i = 0; i < gvEvaluations.Rows.Count; i++)
            {
                for (int j = 0; j < gvEvaluations.Columns.Count; j++)
                {
                    table.AddCell(gvEvaluations.Rows[i].Cells[j].Text);
                }
            }
            document.Add(table);
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Evaluations.pdf");
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.End();
        }
    }
}