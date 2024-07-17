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



using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class ViewAllSupervisorAssignment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Supervisors.full_name AS supervisor_name, Supervisors.email, Supervisors.department, Project.project_title, Project.project_description FROM Supervisors JOIN Project ON Supervisors.supervisor_id = Project.leader_ID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void btnDownloadPDF_Click(object sender, EventArgs e)
    {
        Document document = new Document();
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Server.MapPath("~/SupervisorsProjects.pdf"), FileMode.Create));
        document.Open();
        PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);
        foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
        {
            PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
            pdfTable.AddCell(pdfCell);
        }
        foreach (GridViewRow gridViewRow in GridView1.Rows)
        {
            foreach (TableCell gridViewCell in gridViewRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text));
                pdfTable.AddCell(pdfCell);
            }
        }
        document.Add(pdfTable);
        document.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=SupervisorsProjects.pdf");
        Response.TransmitFile(Server.MapPath("~/SupervisorsProjects.pdf"));
        Response.End();
    }
}
