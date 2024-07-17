<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllProjectsDetails.aspx.cs" Inherits="ViewAllProjectsDetails" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Projects Details</title>
    <style>
        body {
            background-color: #121212;
            color: #e0e0e0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
        form {
            margin: 20px;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #1e1e1e;
            color: #e0e0e0;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #333;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #333;
        }
        .grid-view tr:nth-child(odd) {
            background-color: #2c2c2c;
        }
        .grid-view tr:nth-child(even) {
            background-color: #333;
        }
        .button {
            background-color: #6200ea; /* A vibrant color for the button */
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .button:hover {
            background-color: #3700b3; /* Darker shade for hover effect */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                <asp:BoundField DataField="project_description" HeaderText="Project Description" />
                <asp:BoundField DataField="leader_name" HeaderText="Leader Name" />
                <asp:BoundField DataField="group_name" HeaderText="Group Name" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnDownloadPDF" runat="server" Text="Download as PDF" OnClick="btnDownloadPDF_Click" CssClass="button" />
    </form>
</body>
</html>
