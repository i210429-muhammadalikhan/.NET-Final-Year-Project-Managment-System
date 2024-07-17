<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllFeedbackBySupervisor.aspx.cs" Inherits="ViewAllFeedbackBySupervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View All Feedback by Supervisor</title>
    <style>
        body {
            background-color: #121212;
            color: #e0e0e0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
        }
        #form1 {
            padding: 20px;
        }
        .grid-view {
            border-collapse: collapse;
            width: 100%;
            margin-top: 20px;
        }
        .grid-view th,
        .grid-view td {
            border: 1px solid #333;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #333;
            color: #fff;
        }
        .grid-view tr:nth-child(odd) {
            background-color: #2c2c2c;
        }
        .grid-view tr:nth-child(even) {
            background-color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewFeedback" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="FeedbackID" HeaderText="Feedback ID" />
                    <asp:BoundField DataField="GroupID" HeaderText="Group ID" />
                    <asp:BoundField DataField="AssignmentID" HeaderText="Assignment ID" />
                    <asp:BoundField DataField="AssignmentDescription" HeaderText="Assignment Description" />
                    <asp:BoundField DataField="FeedbackDate" HeaderText="Feedback Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="FeedbackText" HeaderText="Feedback Text" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
