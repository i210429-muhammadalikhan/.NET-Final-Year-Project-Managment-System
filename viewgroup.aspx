<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewgroup.aspx.cs" Inherits="viewgroup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group Information</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form runat="server">
        <h2>Student Information</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="ID" />
                <asp:BoundField DataField="full_name" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="department" HeaderText="Department" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
