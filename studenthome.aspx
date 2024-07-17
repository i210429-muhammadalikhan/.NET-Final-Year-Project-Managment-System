<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studenthome.aspx.cs" Inherits="studenthome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Home Screen</title>
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
            height: 520px;
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
        h1 {
            text-align: center;
            color: #007bff;
        }
        .student-info {
            margin-top: 20px;
        }
        .label {
            font-weight: bold;
        }
        .value {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <div class="welcome-message">
        Welcome to Student Home Screen
    </div>
    <form id="form1" runat="server" class="container">
    <div class="left-column">
        <h1 class="welcome-text">Welcome Student</h1>
        <h1>Student Information</h1>
        <br>

        <div class="student-info">
            <div class="label">Student ID:</div>
            <div class="value"><asp:Label ID="lblStudentID" runat="server"></asp:Label></div>
        </div>
        <div class="student-info">
            <div class="label">Full Name:</div>
            <div class="value"><asp:Label ID="lblFullName" runat="server"></asp:Label></div>
        </div>
        <div class="student-info">
            <div class="label">Email:</div>
            <div class="value"><asp:Label ID="lblEmail" runat="server"></asp:Label></div>
        </div>
        <div class="student-info">
            <div class="label">Phone:</div>
            <div class="value"><asp:Label ID="lblPhone" runat="server"></asp:Label></div>
        </div>
        <div class="student-info">
            <div class="label">Department:</div>
            <div class="value"><asp:Label ID="lblDepartment" runat="server"></asp:Label></div>
        </div>
      
        <asp:Button ID="btnUpdatedProfile" runat="server" Text="Update Profile" OnClick="btnUpdatedProfile_Click" />
        <asp:Button ID="btnStudentGroupCreation" runat="server" Text="Student Group Creation" OnClick="btnStudentGroupCreation_Click" />
        <asp:Button ID="btnSupervisorAssignment" runat="server" Text="Supervisor Assignment" OnClick="btnSupervisorAssignment_Click" />
        <asp:Button ID="btnGroupMemberManagement" runat="server" Text="Group Member Management" OnClick="btnGroupMemberManagement_Click" />
        <asp:Button ID="btnProjectTitleDescription" runat="server" Text="Project Title & Description" OnClick="btnProjectTitleDescription_Click" />
        <asp:Button ID="btnFeedbackBySupervisor" runat="server" Text="Feedback by Supervisor" OnClick="btnFeedbackBySupervisor_Click" />
        <asp:Button ID="btnViewProjectDetails" runat="server" Text="View Project Details" OnClick="btnViewProjectDetails_Click" />
        <asp:Button ID="btnViewAssignedPanels" runat="server" Text="View Assigned Panels" OnClick="btnViewAssignedPanels_Click" />
        <asp:Button ID="btnEvaluationBySupervisor" runat="server" Text="Evaluation by Supervisor" OnClick="btnEvaluationBySupervisor_Click" />
        <asp:Button ID="btnDeadlinesForSubmissions" runat="server" Text="Deadlines for Submissions" OnClick="btnDeadlinesForSubmissions_Click" />
        <asp:Button ID="btnViewGradesOfFYPs" runat="server" Text="View Grades of FYPs" OnClick="btnViewGradesOfFYPs_Click" />
        <asp:Button ID="btnSearchSpecificProjects" runat="server" Text="Search Specific Projects" OnClick="btnSearchSpecificProjects_Click" />
        <asp:Button ID="ViewGroup" runat="server" Text="View Group info" OnClick="btnViewGroupInfo" />
        <asp:Button ID="Viewsupervisor" runat="server" Text="View Supervisor info" OnClick="btnViewSupervisorInfo" />


        </div>
</form>

</body>
</html>
