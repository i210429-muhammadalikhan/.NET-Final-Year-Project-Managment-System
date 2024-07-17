using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SuperVisorHomeScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // You can add any page initialization logic here, if needed
    }

    // Event handlers for each button click
    protected void btnViewStudentGroups_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewStudentGroups.aspx");

        
    }
  

   
    protected void btnViewSupervisors_Click(object sender, EventArgs e)
    {
        // Logic to handle the View Supervisors button click
        // Redirect to the appropriate page or perform any other action
    }

    protected void btnViewFeedbacks_Click(object sender, EventArgs e)
    {
        Response.Redirect("GiveFeedBackToGroups.aspx");

    }

    protected void btnViewProjectDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("VeiwProjectAssigned.aspx");

        
        // Logic to handle the View Project Details button click
        // Redirect to the appropriate page or perform any other action
    }

    protected void btnViewAssignedPanels_Click(object sender, EventArgs e)
    {
        // Logic to handle the View Assigned Panels button click
        // Redirect to the appropriate page or perform any other action
    }

    protected void btnViewEvaluations_Click(object sender, EventArgs e)
    {
        // Logic to handle the View Evaluations button click
        // Redirect to the appropriate page or perform any other action
    }

    protected void btnViewDeadlines_Click(object sender, EventArgs e)
    {
        // Logic to handle the View Deadlines button click
        // Redirect to the appropriate page or perform any other action
    }

    protected void btnViewGrades_Click(object sender, EventArgs e)
    {
        // Logic to handle the View Grades of FYPs button click
        // Redirect to the appropriate page or perform any other action
    }
}