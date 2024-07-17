using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class ViewAssignedPanels : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPanelData();
        }
    }

    private void BindPanelData()
    {
        // Connection string to your database
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // SQL query to fetch panel assignments with related information
        string query = @"SELECT PGA.panel_id, PM.full_name, PM.email, PM.phone, PM.registration_id, PM.department, G.group_id, G.group_name, G.project_title, G.group_leader_id
                FROM PanelGroupAssignment PGA
                INNER JOIN Panel_PanelMembers PPM ON PGA.panel_id = PPM.panel_id
                INNER JOIN PanelMembers PM ON PPM.panel_member_id = PM.panel_member_id
                INNER JOIN Groups G ON PGA.group_id = G.group_id";


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
                GridViewPanels.DataSource = dt;
                GridViewPanels.DataBind();
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        Document document = new Document();
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Server.MapPath("~/SupervisorsProjects.pdf"), FileMode.Create));
        document.Open();
        PdfPTable pdfTable = new PdfPTable(GridViewPanels.HeaderRow.Cells.Count);
        foreach (TableCell headerCell in GridViewPanels.HeaderRow.Cells)
        {
            PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
            pdfTable.AddCell(pdfCell);
        }
        foreach (GridViewRow gridViewRow in GridViewPanels.Rows)
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
