<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateStudentProfile.aspx.cs" Inherits="UpdateStudentProfile" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Update Student Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Student Profile</h1>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Display Your info" OnClick="btnSearch_Click" />
            <br />
            <asp:Label ID="lblFullName" runat="server" Text="Full Name:"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDepartment" runat="server" Text="Department:"></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </form>
</body>
</html>