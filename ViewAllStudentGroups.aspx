<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllStudentGroups.aspx.cs" Inherits="ViewAllStudentGroups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Student Groups</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #form1 {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            color: #333;
        }

        #lblSearch {
            font-weight: bold;
            color: #555;
        }

        .radioGroup {
            margin-bottom: 10px;
        }

        .radioGroup label {
            margin-right: 10px;
            cursor: pointer;
        }

        #txtSearch {
            padding: 8px;
            width: calc(100% - 100px);
            border-radius: 3px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
        }

        #btnSearch, #btnDisplayAll, #btnPrintPDF {
            padding: 8px 20px;
            border: none;
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            border-radius: 3px;
        }

        #btnSearch:hover, #btnDisplayAll:hover, #btnPrintPDF:hover {
            background-color: #0056b3;
        }

        #gvGroups {
            border-collapse: collapse;
            width: 100%;
        }

        #gvGroups th, #gvGroups td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        #gvGroups th {
            background-color: #007bff;
            color: #fff;
        }

        #gvGroups tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        #btnPrintPDF {
            margin-top: 20px;
            background-color: #28a745;
        }

        #btnPrintPDF:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View All Student Groups</h1>
            <div class="radioGroup">
                <asp:Label ID="lblSearch" runat="server" Text="Search by:"></asp:Label>
                <asp:RadioButton ID="rbGroupID" runat="server" Text="Group ID" GroupName="searchType" />
                <asp:RadioButton ID="rbLeader" runat="server" Text="Leader (Student Name)" GroupName="searchType" />
                <asp:RadioButton ID="rbGroupTitle" runat="server" Text="Group Title" GroupName="searchType" />
                <asp:RadioButton ID="rbAll" runat="server" Text="Display All" GroupName="searchType" />
            </div>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnDisplayAll" runat="server" Text="Display All" OnClick="btnDisplayAll_Click" />
            <br />
            <asp:GridView ID="gvGroups" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                    <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="leader_name" HeaderText="Leader (Student Name)" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnPrintPDF" runat="server" Text="Print List of Groups in PDF" OnClick="btnPrintPDF_Click" />
        </div>
    </form>
</body>
</html>
