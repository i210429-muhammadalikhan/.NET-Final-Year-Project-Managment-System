using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FYPCommitteeHomeScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPanelCreation_Click(object sender, EventArgs e)
    {
        Response.Redirect("PanelCreationByFYPCommittee.aspx");
    }

    protected void btnViewStudentGroups_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAllStudentGroups.aspx");

        // Code to view student groups goes here
    }

    protected void btnViewSupervisorAssignment_Click(object sender, EventArgs e)
    {
        // Code to view supervisor assignment goes here
        Response.Redirect("ViewAllSupervisorAssignment.aspx");

    }

    protected void btnViewProjectsDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAllProjectsDetails.aspx");
    }

    protected void btnViewFeedbackBySupervisor_Click(object sender, EventArgs e)
    {

        Response.Redirect("ViewAllFeedbackBySupervisor.aspx");


    }

    protected void btnViewAssignedPanels_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAssignedPanels.aspx");


    }

    protected void btnViewEvaluationBySupervisor_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAllEvaluationByPanel.aspx");

    }

    protected void btnViewDeadlines_Click(object sender, EventArgs e)
    {

                    Response.Redirect("MakeSubmissions.aspx");



    }

    protected void btnViewGradesOfFYPs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAllGradesOfFYPs.aspx");
    }

    protected void btnSearchSpecificProjects_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchSpecificProjects.aspx");
    }


    protected void btnCreateEvaluationForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateEvaluation.aspx");
    }

    protected void btnPanelGroupAssign_Click(object sender, EventArgs e)
    {
        Response.Redirect("PanelGroupAssign.aspx");
    }


}