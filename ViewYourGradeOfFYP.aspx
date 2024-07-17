<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewYourGradeOfFYP.aspx.cs" Inherits="ViewYourGradeOfFYP" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>View Your Grade of FYP</title>
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
        
        .label {
            color: #ffa500;
            margin-right: 10px;
        }
        
        .btn-download {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            margin-top: 20px;
        }
        
        .btn-download:hover {
            background-color: #ff7f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View Your Grade of FYP</h1>
            <asp:GridView ID="gvEvaluation" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="EvaluationID" HeaderText="Evaluation ID" />
                    <asp:BoundField DataField="GroupID" HeaderText="Group ID" />
                    <asp:BoundField DataField="EvaluationDate" HeaderText="Evaluation Date" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                    <asp:BoundField DataField="QuestionID" HeaderText="Question ID" />
                    <asp:BoundField DataField="MarksObtained" HeaderText="Marks Obtained" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks: 0" CssClass="label" />
            <asp:Label ID="lblGrade" runat="server" Text="Grade: " CssClass="label" />
            <asp:Button ID="btnDownload" runat="server" Text="Download Result" OnClick="btnDownload_Click" CssClass="btn-download" />
        </div>
    </form>
</body>
</html>
