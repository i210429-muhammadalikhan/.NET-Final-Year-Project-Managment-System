<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAssignedPanels.aspx.cs" Inherits="ViewAssignedPanels" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Assigned Panels</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewPanels" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="panel_id" HeaderText="Panel ID" />
                    <asp:BoundField DataField="full_name" HeaderText="Panel Member Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="registration_id" HeaderText="Registration ID" />
                    <asp:BoundField DataField="department" HeaderText="Department" />
                    <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                    <asp:BoundField DataField="group_name" HeaderText="Group Name" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="group_leader_id" HeaderText="Group Leader ID" />
                </Columns>
            </asp:GridView>
                        <asp:Button ID="btnPrint" runat="server" Text="Print List" OnClick="btnPrint_Click" />

        </div>
    </form>
</body>
</html>
