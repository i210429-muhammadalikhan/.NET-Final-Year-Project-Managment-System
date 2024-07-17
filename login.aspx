<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
         body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to bottom, #ffcc00, #0056b3);
        }

        .container {
            width: 400px;
            margin: 50px 0 50px 50px;
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 24px;
            box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.1);
        }

        .top {
            display: flex;
            justify-content: center;
            margin-bottom: 24px;
        }

        .top img {
            max-width: 100%;
            height: auto;
        }

        h1 {
            font-family: "Times New Roman", Times, serif;
            font-weight: bold;
            font-size: 35px;
            text-align: center;
            line-height: 1;
            color: #0056b3;
            text-shadow: 2px 2px 4px #ddd;
        }

        h2 {
            font-family: Georgia, serif;
            text-align: center;
            margin-bottom: 24px;
            color: #000;
            text-shadow: 2px 2px 4px #ddd;
        }

        .label {
            display: inline-block;
            width: 100px;
            font-weight: bold;
            color: #007bff;
            text-transform: uppercase;
            margin-bottom: 4px;
        }

        .sample-email {
            font-weight: normal;
            font-size: 12px;
            color: #777;
            margin-left: 4px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 6px 12px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .button-container {
            display: flex;
            justify-content: space-between;
        }

        input[type="submit"] {
            width: calc(50% - 10px);
            padding: 10px 0;
            background: linear-gradient(to bottom, #007bff, #0056b3);
            color: white;
            font-weight: normal;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            margin-top: 45px;
            box-shadow: 0px 2px 2px #888;
            font-family: 'Times New Roman', serif;
        }

        input[type="submit"]:hover {
            background-color: #ffd800;
        }

        .radio-group {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            justify-content: space-between;
        }

        .top-right-img {
            position: absolute;
            top: 50px;
            right: 0;
            max-width: 770px; 
            height: auto; 
            margin: 0 0 50px 50px;
            background-color: dodgerblue;
            border: 1px medium #ddd;
            border-radius: 1px;
            padding: 30px;
        }

        .heading-spacing {
            margin-bottom: 40px;
        }

    </style>
</head>

<body>
    <form id="loginForm" runat="server">
        <div class="container">

  <div class="left">
            <img src="http://www.nu.edu.pk/Content/images/Slider/01.jpg" alt="Uni Image" class="top-right-img">
        </div>

            <div class="right">
                <h1>Welcome to Final Year Project Management System</h1>
                <div class="heading-spacing"></div>
                <h2>Log In</h2>

                <label for="username">Email:</label>
                <input type="text" id="username"  runat="server" />

                <span class="sample-email">(Email i.e. Id@nu.edu.pk)</span><br /><br />
                
                <label for="password">Password:</label>
                <input type="password" id="password"  runat="server" /><br /><br />
                
                <label for="userRole">Role: </label>
                <select id="userRole" name="userRole" runat="server">
                    <option value="1">Admin</option>
                    <option value="2">Student</option>
                    <option value="3">FYP Committee Member</option>           
                    <option value="4">Supervisor</option>
                    <option value="5">Panel Member</option>
                </select>
                <br />
                <div class="button-container">
                    <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="LoginButton_Click" />
                    <asp:Button ID="signUpButton" runat="server" Text="Don't have an account? Sign Up" OnClick="SignUpButton_Click" />
                </div>
                <span id="ErrorMessage" runat="server" style="color: red; visibility: hidden;"></span>
            </div>
        </div>
    </form>
</body>
</html>
