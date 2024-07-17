<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchSpecificProjects.aspx.cs" Inherits="SearchSpecificProjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Specific Projects</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }
        form {
            max-width: 600px;
            margin: 40px auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ddd;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #333;
            margin-bottom: 20px;
        }
        label {
            display: block;
            margin-bottom: 10px;
        }
        radio {
            margin-bottom: 10px;
        }
        input[type="text"] {
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            width: 100%;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #3e8e41;
        }
        .gridview {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
        }
        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }
        .gridview th {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Search Specific Projects</h1>
            <asp:Label ID="lblSearch" runat="server" Text="Search by:"></asp:Label>
            <asp:RadioButton ID="rbProjectID" runat="server" Text="Project ID" GroupName="searchType" />
            <asp:RadioButton ID="rbProjectTitle" runat="server" Text="Project Title" GroupName="searchType" />
            <asp:RadioButton ID="rbDepartment" runat="server" Text="Department" GroupName="searchType" />
            <br />
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <br />
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="project_id" HeaderText="Project ID" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="leader_name" HeaderText="Leader Name" />
                    <asp:BoundField DataField="department" HeaderText="Department" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>