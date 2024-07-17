<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateSubmission.aspx.cs" Inherits="UpdateSubmission" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Update Submission</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        h2 {
            color: #ffa500;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-label {
            color: #ffa500;
            display: block;
            margin-bottom: 5px;
        }
        
        .form-input {
            width: 100%;
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
            margin-bottom: 10px;
            box-sizing: border-box;
        }
        
        .form-textarea {
            width: 100%;
            height: 100px;
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
            margin-bottom: 10px;
            resize: none;
            box-sizing: border-box;
        }
        
        .btn-update {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        
        .btn-update:hover {
            background-color: #ff7f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Submission</h2>
            <div class="form-group">
                <asp:Label ID="lblSubmissionId" runat="server" Text="Submission ID:" CssClass="form-label"></asp:Label>
                <asp:Label ID="lblSubmissionIdValue" runat="server" CssClass="form-input"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblGroupId" runat="server" Text="Group ID:" CssClass="form-label"></asp:Label>
                <asp:Label ID="lblGroupIdValue" runat="server" CssClass="form-input"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDeliveredTime" runat="server" Text="Delivered Time:" CssClass="form-label"></asp:Label>
                <asp:Label ID="lblDeliveredTimeValue" runat="server" CssClass="form-input"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSubmissionStatus" runat="server" Text="Submission Status:" CssClass="form-label"></asp:Label>
                <asp:Label ID="lblSubmissionStatusValue" runat="server" CssClass="form-input"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrivateComment" runat="server" Text="Private Comment:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPrivateComment" runat="server" TextMode="MultiLine" CssClass="form-textarea"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn-update" />
            </div>
        </div>
    </form>
</body>
</html>
