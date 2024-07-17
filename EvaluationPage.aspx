<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluationPage.aspx.cs" Inherits="EvaluationPage" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Evaluation Page</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
        }
        
        .container {
            margin: 0 auto;
            max-width: 800px;
            padding: 20px;
        }
        
        h1 {
            color: #ffa500;
        }
        
        #gvEvaluation {
            background-color: #333;
            border-color: #444;
            color: #fff;
        }
        
        #gvEvaluation th {
            background-color: #444;
            color: #ffa500;
        }
        
        #gvEvaluation tr:nth-child(even) {
            background-color: #444;
        }
        
        #gvEvaluation tr:hover {
            background-color: #555;
        }
        
        #btnSubmit {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        
        #btnSubmit:hover {
            background-color: #ff7f00;
        }
        
        .textbox {
            background-color: #333;
            color: #fff;
            border: 1px solid #444;
            padding: 5px;
        }
        
        .textbox:focus {
            border-color: #ffa500;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Evaluation Page</h1>
            <asp:GridView ID="gvEvaluation" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="QuestionID" HeaderText="Question ID" />
                    <asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                    <asp:TemplateField HeaderText="Marks Obtained">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMarksObtained" CssClass="textbox" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRemarks" CssClass="textbox" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
