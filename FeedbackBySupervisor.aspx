<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedbackBySupervisor.aspx.cs" Inherits="FeedbackBySupervisor" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Feedback By Supervisor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Feedback By Supervisor</h1>
            <asp:GridView ID="gvFeedback" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="FeedbackText" HeaderText="Feedback Text" />
                    <asp:BoundField DataField="AssignmentDescription" HeaderText="Assignment Description" />
                    <asp:BoundField DataField="FeedbackDate" HeaderText="Feedback Date" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>