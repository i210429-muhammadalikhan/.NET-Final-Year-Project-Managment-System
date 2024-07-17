using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PanelHomeScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnViewCreatedPanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewYourPanel.aspx");


    }

    protected void btnViewStudentGroups_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewYourPanelGroups.aspx");

    }

    protected void btnViewSupervisorAssignment_Click(object sender, EventArgs e)
    {
        // Code to view supervisor assignment goes here
    }

    protected void btnViewProjectsDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewYourPanelProject.aspx");
    }

    protected void btnViewFeedbackBySupervisor_Click(object sender, EventArgs e)
    {
        // Code to view feedback by supervisor goes here
    }

    protected void btnViewDeadlines_Click(object sender, EventArgs e)
    {
        // Code to view deadlines goes here
    }

    protected void btnViewGradesOfFYPs_Click(object sender, EventArgs e)
    {
        // Code to view grades of FYPs goes here
    }

    protected void btnSearchSpecificProjects_Click(object sender, EventArgs e)
    {
        // Code to search specific projects goes here
    }

}