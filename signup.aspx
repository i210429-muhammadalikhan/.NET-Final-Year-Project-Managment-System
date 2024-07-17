<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
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

        input[type="submit"] {
            width: 50%;
            padding: 10px 0;
            background: linear-gradient(to bottom, #007bff, #0056b3);
            color: white;
            font-weight: normal;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            margin-top: 45px;
            margin-left: 40px;
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

        .logo {
            width: 300px;
            margin: 0 auto;
            display: block;
            margin-bottom: 24px;
        }

        .top-right-img {
            position: absolute;
            top: 50px;
            right: 0;
            max-width: 770px; /* Adjust the maximum width as needed */
            height: auto; /* This will maintain the aspect ratio */
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
 
    <form id="form1" runat="server" class="container">
        <div class="left">
            <img src="(link unavailable)" alt="Uni Image" class="top-right-img">
        </div>
        <div class="right">
            <h1>Welcome to Final Year Project Management System</h1>
            <div class="heading-spacing"></div>
            <h2>Sign Up</h2>
            <label for="firstName">First Name:</label>
            <input type="text" id="firstName" name="firstName" runat="server" /><br /><br />
            <label for="lastName">Last Name:</label>
            <input type="text" id="lastName" name="lastName" runat="server" /><br /><br />
            <label for="regID">Registration ID:</label>
            <input type="text" id="regID" name="regID" runat="server" /><br /><br />
            <label for="department">Department name:</label>
            <input type="text" id="department" name="department" runat="server" /><br /><br />
            <label for="username">Email:</label>
            <input type="text" id="username" name="username" runat="server" />
            <label for="phonenumber">Phone:</label>
            <input type="text" id="phonenumber" name="phonenumber" runat="server" />  
            <span class="sample-email">(Email i.e. Id@nu.edu.pk)</span><br /><br />
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" runat="server" /><br /><br />
            <label for="confirmPassword">Confirm Password:</label>
            <input type="password" id="confirmPassword" name="confirmPassword" runat="server" /><br /><br />
            <label for="userRole">Role: </label>
            <select id="userRole" name="userRole" runat="server">
                <option value="2">Student</option>
            </select>
            <br />
            <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" OnClick="SignUpButton_Click" />
            <span id="ErrorMessage" runat="server" style="color: red; visibility: hidden;"></span>
        </div>
    </form>

</body>
</html>

