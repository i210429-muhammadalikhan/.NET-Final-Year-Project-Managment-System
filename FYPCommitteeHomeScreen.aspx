<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FYPCommitteeHomeScreen.aspx.cs" Inherits="FYPCommitteeHomeScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FYP Committee Home Screen</title>
    <style>

        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to bottom, #ffcc00, #0056b3);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            position: relative;
        }

        .welcome-message {
            position: absolute;
            top: 20px;
            left: 50%;
            transform: translateX(-50%);
            font-size: 22px;
            font-weight: bold;
            color: white;
        }

        .container {
            width: 800px;
            height: 420px;
            background-color: #ffffb3; /* Light yellow background color */
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 24px;
            box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-wrap: wrap;
            justify-content: center; /* Center content horizontally */
            align-items: center; /* Center content vertically */
            margin-top: 50px;
        }

        .left-column,
        .right-column {
            width: 100%; /* Full width for left and right columns */
        }

        .form-group {
            margin-bottom: 40px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 10px;
        }

        input[type="text"],
        input[type="number"],
        select {
            width: calc(100% - 12px);
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        input[type="submit"] {
            width: calc(25% - 10px); /* Smaller width */
            padding: 20px 0;
            color: white;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            box-shadow: 0px 2px 2px #888;
            font-family: 'Times New Roman', serif;
            margin-top: 5px; /* Adjusted margin to create space between text and buttons */
            margin-right: 5px;
            transition: background-color 0.3s; /* Smooth transition for hover effect */
            animation: blink 1s infinite alternate; /* Blink animation */
        }

        @keyframes blink {
            0% {
                background-color: #007bff; /* Original blue color */
            }
            100% {
                background-color: #ffd800; /* Yellow color */
            }
        }

        .error-message {
            color: red;
            font-size: 14px;
            margin-top: 5px;
        }

        .additional-options {
            margin-top: 20px;
            display: none;
        }
        
        .welcome-text {
            font-weight: bold;
            font-size: 20px;
            margin-top: -150px; /* Move the text up */
            text-align: center;
            color: #007bff; /* Blue color */
        }
        
        .explore-text {
            font-weight: bold;
            font-size: 18px;
            margin-top: -100px; /* Move the text up */
            text-align: center;
            color: #ff8000; /* Orange color */
        }
        
    </style>
</head>
<body>

    <div class="welcome-message">
        Welcome to FYP Committee Home Screen
    </div>

    <form id="form1" runat="server" class="container">
        <div class="left-column">
            <h1 class="welcome-text">Welcome FYP Committee Member</h1>

            <br>
            <br>
            <br>
            <br>
            <br>

           <asp:Button ID="btnPanelCreation" runat="server" Text="Panel Creation" OnClick="btnPanelCreation_Click" />
<asp:Button ID="btnViewStudentGroups" runat="server" Text="View Student Groups" OnClick="btnViewStudentGroups_Click" />
<asp:Button ID="btnViewSupervisorAssignment" runat="server" Text="View Supervisor Assignment" OnClick="btnViewSupervisorAssignment_Click" />
<asp:Button ID="btnViewProjectsDetails" runat="server" Text="View Projects Details" OnClick="btnViewProjectsDetails_Click" />
<asp:Button ID="btnViewFeedbackBySupervisor" runat="server" Text="View Feedback by Supervisor" OnClick="btnViewFeedbackBySupervisor_Click" />
<asp:Button ID="btnViewAssignedPanels" runat="server" Text="View Assigned Panels" OnClick="btnViewAssignedPanels_Click" />
<asp:Button ID="btnViewEvaluationBySupervisor" runat="server" Text="View Evaluation by Supervisor" OnClick="btnViewEvaluationBySupervisor_Click" />
<asp:Button ID="btnViewDeadlines" runat="server" Text="Make  Submissions" OnClick="btnViewDeadlines_Click" />
<asp:Button ID="btnViewGradesOfFYPs" runat="server" Text="View Grades of FYPs" OnClick="btnViewGradesOfFYPs_Click" />
<asp:Button ID="btnSearchSpecificProjects" runat="server" Text="Search Specific Projects" OnClick="btnSearchSpecificProjects_Click" />
<asp:Button ID="btnCreateEvaluationForm" runat="server" Text="Create Evaluation Form" OnClick="btnCreateEvaluationForm_Click" />
<asp:Button ID="btnPanelGroupAssign" runat="server" Text="Assign Penal To Groups" OnClick="btnPanelGroupAssign_Click" />


        </div>
    </form>

</body>
</html>
