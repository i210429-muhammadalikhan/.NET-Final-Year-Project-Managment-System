<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewandFeedbackbySupervisoronProjectSubmissions.aspx.cs" Inherits="ReviewandFeedbackbySupervisoronProjectSubmissions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Review and Feedback by Supervisor Page</title>
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
            font-size: 16px;
            font-weight: bold;
            color: white;
        }

        .container {
            width: 800px;
            height: 530px;
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
            width: 50%;
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
            width: 100%;
            padding: 10px 0;
            background: linear-gradient(to bottom, #007bff, #0056b3);
            color: white;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            box-shadow: 0px 2px 2px #888;
            font-family: 'Times New Roman', serif;
            margin-top: 40px;
            margin-right: 10px;
            transition: background-color 0.3s; /* Smooth transition for hover effect */
        }

        input[type="submit"]:hover {
            background-color: #ffd800; /* Yellow color on hover */
            animation: glitter 1s infinite alternate; /* Glitter effect on hover */
        }

        @keyframes glitter {
            0% {
                background-color: #007bff; /* Original blue color */
                box-shadow: 0px 2px 2px #888;
            }
            100% {
                background-color: #ffd800; /* Yellow color */
                box-shadow: 0px 2px 10px #ffd800, 0px 2px 10px #ffd800; /* Glitter effect */
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
        
    </style>
</head>
<body>

    <div class="welcome-message">
        Welcome to Review and Feedback by Supervisor on Project Submissions Page
    </div>
    <form id="form1" runat="server" class="container">
        <div class="left-column">

            <div class="form-group">
                <label for="projectName">Enter Project Name:</label>
                <input type="text" id="projectName" name="projectName" />
            </div>

            <div class="form-group">
                <label for="SupervisorName">Enter Your Name:</label>
                <input type="text" id="SupervisorName" name="SupervisorName" />
            </div>


            <div class="form-group">
                <label for="Review">Enter Your Review on Student Project Submission:</label>
                <input type="text" id="Review" name="Review" />
            </div>


            <div class="form-group">
                <label for="AdditionalComments">Enter Additional Comments:</label>
                <input type="text" id="AdditionalComments" name="AdditionalComments" />
            </div>

           
            <input type="submit" value="Submit Your Review and Feedback" />
        </div>

    </form>
  </body>
</html>
