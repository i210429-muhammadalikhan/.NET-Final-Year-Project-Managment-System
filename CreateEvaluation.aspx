<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateEvaluation.aspx.cs" Inherits="CreateEvaluation" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Create Evaluation</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        h1 {
            color: #ffa500;
            margin-bottom: 20px;
        }
        
        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        
        table td {
            padding: 10px;
            border: 1px solid #444;
        }
        
        table td:first-child {
            width: 150px;
            background-color: #333;
        }
        
        input[type="text"], input[type="button"] {
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
            width: 100%;
            box-sizing: border-box;
        }
        
        input[type="button"] {
            cursor: pointer;
            background-color: #ffa500;
            color: #fff;
            border: none;
        }
        
        input[type="button"]:hover {
            background-color: #ff7f00;
        }
        
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }
        
        .gridview th, .gridview td {
            border: 1px solid #444;
            padding: 8px;
            text-align: left;
        }
        
        .gridview th {
            background-color: #333;
            color: #ffa500;
        }
        
        .gridview tr:nth-child(even) {
            background-color: #444;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Create Evaluation</h1>
            <table>
                <tr>
                    <td>Question Description:</td>
                    <td><asp:TextBox ID="txtQuestionDescription" runat="server" CssClass="text-input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Total Marks:</td>
                    <td><asp:TextBox ID="txtTotalMarks" runat="server" CssClass="text-input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnCreateQuestion" runat="server" Text="Create Question" OnClick="btnCreateQuestion_Click" CssClass="btn-submit"></asp:Button></td>
                </tr>
            </table>
            <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="QuestionID" HeaderText="Question ID" />
                    <asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
