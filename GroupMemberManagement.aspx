<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupMemberManagement.aspx.cs" Inherits="GroupMemberManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group Member Management Page</title>
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
        
        label {
            color: #ffa500;
            margin-right: 10px;
        }
        
        .textbox {
            background-color: #333;
            color: #fff;
            border: 1px solid #444;
            padding: 5px;
            margin-bottom: 10px;
        }
        
        .textbox:focus {
            border-color: #ffa500;
        }
        
        .btn {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            margin-bottom: 10px;
        }
        
        .btn:hover {
            background-color: #ff7f00;
        }
        
        #gvMembers {
            background-color: #333;
            color: #fff;
            border: 1px solid #444;
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 20px;
        }
        
        #gvMembers th {
            background-color: #444;
            color: #ffa500;
            padding: 8px;
            border: 1px solid #444;
        }
        
        #gvMembers td {
            padding: 8px;
            border: 1px solid #444;
        }
        
        #gvMembers tr:nth-child(even) {
            background-color: #444;
        }
        
        #gvMembers tr:hover {
            background-color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Group Member Management Page</h1>
            <label for="lblGroupName">Group Name:</label>
            <asp:Label ID="lblGroupName" runat="server"></asp:Label>
            <br />
            <label for="lblGroupLeader">Group Leader:</label>
            <asp:Label ID="lblGroupLeader" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                    <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
            <br />
            <label for="lblAddMember">Add Member:</label>
            <asp:TextBox ID="txtAddMember" CssClass="textbox" runat="server"></asp:TextBox>
            <asp:Button ID="btnAddMember" CssClass="btn" runat="server" Text="Add" OnClick="btnAddMember_Click" />
            <br />
            <label for="lblRemoveMember">Remove Member:</label>
            <asp:TextBox ID="txtRemoveMember" CssClass="textbox" runat="server"></asp:TextBox>
            <asp:Button ID="btnRemoveMember" CssClass="btn" runat="server" Text="Remove" OnClick="btnRemoveMember_Click" />
        </div>
    </form>
</body>
</html>
