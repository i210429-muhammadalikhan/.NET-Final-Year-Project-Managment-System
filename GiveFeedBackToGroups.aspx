<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GiveFeedBackToGroups.aspx.cs" Inherits="GiveFeedBackToGroups" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Give Feedback to Groups</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Give Feedback to Groups</h2>
            <asp:GridView ID="gvGroups" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupID">
                <Columns>
                    <asp:BoundField DataField="GroupID" HeaderText="GroupID" InsertVisible="False" ReadOnly="True" SortExpression="GroupID" />
                    <asp:BoundField DataField="ProjectTitle" HeaderText="Project Title" SortExpression="ProjectTitle" />
                    <asp:BoundField DataField="LeaderName" HeaderText="Leader Name" SortExpression="LeaderName" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnGiveFeedback" runat="server" CommandArgument='<%# Eval("GroupID") %>' OnClick="btnGiveFeedback_Click" Text="Give Feedback" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlFeedback" runat="server" Visible="false">
                <h2>Give Feedback and Assignmemnt Description</h2>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>

                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                <br />
                <asp:Button ID="btnSubmitFeedback" runat="server" OnClick="btnSubmitFeedback_Click" Text="Submit Feedback" />
                <asp:Label ID="lblFeedbackStatus" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>