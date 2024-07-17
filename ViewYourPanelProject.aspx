<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewYourPanelProject.aspx.cs" Inherits="ViewYourPanelProject" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>View Your Panel Project</title>
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
        
        .btn-select {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
        }
        
        .btn-select:hover {
            background-color: #ff7f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View Your Panel Project</h1>
            <asp:GridView ID="gvProjectInfo" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="project_id" HeaderText="Project ID" />
                    <asp:BoundField DataField="project_description" HeaderText="Project Description" />
                    <asp:BoundField DataField="leader_ID" HeaderText="Leader ID" />
                    <asp:BoundField DataField="leader_name" HeaderText="Leader Name" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                    <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                    <asp:BoundField DataField="group_leader_id" HeaderText="Group Leader ID" />
                    <asp:TemplateField HeaderText="Evaluate">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Select" CommandArgument='<%# Eval("group_id") %>' OnClick="btnSelect_Click" CssClass="btn-select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
