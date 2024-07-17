<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VeiwProjectAssigned.aspx.cs" Inherits="VeiwProjectAssigned" %>


<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Projects Assigned to Supervisor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Projects Assigned to Supervisor</h1>
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="project_description" HeaderText="Project Description" />
                    <asp:BoundField DataField="leader_name" HeaderText="Leader Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>