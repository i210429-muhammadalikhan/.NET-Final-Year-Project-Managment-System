<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStudentGroups.aspx.cs" Inherits="ViewStudentGroups" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supervisor's Groups and Projects</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        h2 {
            color: #333;
        }
        .container {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            background-color: #f9f9f9;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            text-align: left;
            padding: 8px;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #e9e9e9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Groups and Projects for Supervisor </h2>
            <asp:GridView ID="gvGroupsProjects" runat="server" AutoGenerateColumns="false" CssClass="table"> 
                <Columns>
                    <asp:BoundField DataField="GroupName" HeaderText="Group Name" />
                    <asp:BoundField DataField="ProjectTitle" HeaderText="Project Title" />
                    <asp:BoundField DataField="LeaderName" HeaderText="Leader Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>