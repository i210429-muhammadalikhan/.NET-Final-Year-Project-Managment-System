<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllEvaluationByPanel.aspx.cs" Inherits="ViewAllEvaluationByPanel" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Evaluations of Groups</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Evaluations of Groups</h1>
            <asp:GridView ID="gvEvaluations" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="GroupID" HeaderText="Group ID" />
                    <asp:BoundField DataField="EvaluationDate" HeaderText="Evaluation Date" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                    <asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" />
                    <asp:BoundField DataField="MarksObtained" HeaderText="Marks Obtained" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnPrint" runat="server" Text="Print PDF" OnClick="btnPrint_Click" />
        </div>
    </form>
</body>
</html>