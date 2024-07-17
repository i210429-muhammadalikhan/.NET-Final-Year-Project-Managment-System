<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeSubmissions.aspx.cs" Inherits="MakeSubmissions" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Make Submissions</title>
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
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-label {
            color: #ffa500;
            display: block;
            margin-bottom: 5px;
        }
        
        .text-input {
            width: 100%;
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
            margin-bottom: 10px;
            box-sizing: border-box;
        }
        
        .btn-submit {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        
        .btn-submit:hover {
            background-color: #ff7f00;
        }
        
        .gridview {
            border-collapse: collapse;
            width: 100%;
            margin-top: 20px;
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
            <h1>Make Submissions</h1>
            <div class="form-group">
                <asp:Label ID="lblAssignmentDetail" runat="server" Text="Assignment Detail:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtAssignmentDetail" runat="server" CssClass="text-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSubmissionTime" runat="server" Text="Submission Time:" CssClass="form-label"></asp:Label>
                <asp:Calendar ID="calSubmissionTime" runat="server"></asp:Calendar>
                <asp:TextBox ID="txtSubmissionTime" runat="server" CssClass="text-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSubmissionMedium" runat="server" Text="Submission Medium:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtSubmissionMedium" runat="server" CssClass="text-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn-submit" />
            </div>
            <div>
                <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                    <Columns>
                        <asp:BoundField DataField="submission_id" HeaderText="Submission ID" />
                        <asp:BoundField DataField="assignment_detail" HeaderText="Assignment Detail" />
                        <asp:BoundField DataField="submission_time" HeaderText="Submission Time" />
                        <asp:BoundField DataField="submission_medium" HeaderText="Submission Medium" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
