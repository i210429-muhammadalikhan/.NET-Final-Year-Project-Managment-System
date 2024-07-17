<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSubmissions.aspx.cs" Inherits="ViewSubmissions" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>View Submissions</title>
    <style>
        /* Add your CSS styles here */
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        h2 {
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
            <h2>View Submissions</h2>
            <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="False" DataKeyNames="submission_id" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="submission_id" HeaderText="Submission ID" />
                    <asp:BoundField DataField="assignment_detail" HeaderText="Assignment Detail" />
                    <asp:BoundField DataField="submission_time" HeaderText="Submission Time" />
                    <asp:BoundField DataField="submission_medium" HeaderText="Submission Medium" />
                    <asp:TemplateField HeaderText="Update Status">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Select" CommandArgument='<%# Eval("submission_id") %>' OnClick="btnSelect_Click" CssClass="btn-select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
