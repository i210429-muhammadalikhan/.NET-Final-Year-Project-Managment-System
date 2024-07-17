<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentgroupcreation.aspx.cs" Inherits="studentgroupcreation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Group Creation Page</title>
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
            font-size: 24px;
            font-weight: bold;
            color: white;
        }

        .container {
            width: 800px;
            height: 500px;
            background-color: rgba(255, 255, 255, 0.8);
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 24px;
            box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
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
        select,
        asp:TextBox {
            width: calc(100% - 12px);
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        asp:Button {
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
        }

        asp:Button:hover {
            background-color: #ffd800;
        }

        .error-message {
            color: red;
            font-size: 14px;
            margin-top: 5px;
        }
    </style>
</head>
<body>
    <div class="welcome-message">
        Welcome to Student Group Creation Page
    </div>
    <form id="form1" runat="server" class="container">
        <div class="left-column">
            <div class="form-group">
                <label for="projectName">Enter Project Title:</label>
                <asp:TextBox ID="projectName" runat="server" />
            </div>

            <div class="form-group">
                <label for="groupName">Enter Group Name:</label>
                <asp:TextBox ID="groupName" runat="server" />
            </div>
        </div>

        <div class="right-column">
            <div class="form-group">
                <label>Select Group Members:</label>
<asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" CssClass="students-table">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="full_name" HeaderText="Name" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="department" HeaderText="Department" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:Button ID="btnCreateGroup" runat="server" Text="Create Group" OnClick="btnCreateGroup_Click" />
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" />
        </div>
    </form>
</body>
</html>

