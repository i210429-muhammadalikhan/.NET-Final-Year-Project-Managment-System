<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewYourPanelGroups.aspx.cs" Inherits="ViewYourPanelGroups" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>View Your Panel Groups</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        h1 {
            color: #ffa500;
        }
        
        .gridview {
            background-color: #333;
            color: #fff;
            border: 1px solid #444;
            border-collapse: collapse;
            width: 100%;
            margin-top: 20px;
        }
        
        .gridview th {
            background-color: #444;
            color: #ffa500;
            padding: 8px;
            border: 1px solid #444;
        }
        
        .gridview td {
            padding: 8px;
            border: 1px solid #444;
        }
        
        .gridview tr:nth-child(even) {
            background-color: #444;
        }
        
        .gridview tr:hover {
            background-color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View Your Panel Groups</h1>
            <asp:GridView ID="gvGroups" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                    <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
