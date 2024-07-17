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
using System.Configuration;
using System.Data;
using System.IO;

public partial class ViewAllStudentGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchType = "";
        if (rbGroupID.Checked)
        {
            searchType = "group_id";
        }
        else if (rbLeader.Checked)
        {
            searchType = "leader_name";
        }
        else if (rbGroupTitle.Checked)
        {
            searchType = "project_title";
        }
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT g.group_id, g.group_name, g.project_title, s.full_name as leader_name " +
                           "FROM Groups g INNER JOIN Students s ON g.group_leader_id = s.student_id " +
                           "WHERE " + searchType + " LIKE @searchTerm";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchTerm", "%" + txtSearch.Text + "%");
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvGroups.DataSource = dt;
                    gvGroups.DataBind();
                }
            }
        }
    }

    protected void btnDisplayAll_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT g.group_id, g.group_name, g.project_title, s.full_name as leader_name " +
                           "FROM Groups g INNER JOIN Students s ON g.group_leader_id = s.student_id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvGroups.DataSource = dt;
                    gvGroups.DataBind();
                }
            }
        }
    }

    protected void btnPrintPDF_Click(object sender, EventArgs e)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.Add(new Paragraph("Groups Report"));
      
            document.Add(new Paragraph("Groups Details:"));
            PdfPTable table = new PdfPTable(gvGroups.Columns.Count);
            for (int i = 0; i < gvGroups.Columns.Count; i++)
            {
                table.AddCell(gvGroups.Columns[i].HeaderText);
            }
            for (int i = 0; i < gvGroups.Rows.Count; i++)
            {
                for (int j = 0; j < gvGroups.Columns.Count; j++)
                {
                    table.AddCell(gvGroups.Rows[i].Cells[j].Text);
                }
            }
            document.Add(table);
          //  document.Add(new Paragraph("Total Marks: " + lblTotalMarks.Text.Split(':')[1].Trim()));
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=EvaluationReport.pdf");
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.End();
        }
    }
}