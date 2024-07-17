<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAssignedPanel.aspx.cs" Inherits="ViewAssignedPanel" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>View Assigned Panel</title>
    <style>
        /* Add your CSS styles here */
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
            <h1>View Assigned Panel</h1>
            <asp:GridView ID="gvPanelMembers" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="registration_id" HeaderText="Registration ID" />
                    <asp:BoundField DataField="department" HeaderText="Department" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
