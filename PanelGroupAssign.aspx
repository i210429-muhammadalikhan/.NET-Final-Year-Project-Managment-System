<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelGroupAssign.aspx.cs" Inherits="PanelGroupAssign" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Panel Group Assignment</title>
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
        
        .dropdownlist {
            width: 100%;
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
            margin-bottom: 10px;
            box-sizing: border-box;
        }
        
        .btn-assign {
            background-color: #ffa500;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        
        .btn-assign:hover {
            background-color: #ff7f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Panel Group Assignment</h1>
            <div class="form-group">
                <asp:Label ID="lblGroups" runat="server" Text="Select Group:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlGroups" runat="server" AutoPostBack="True" CssClass="dropdownlist">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPanels" runat="server" Text="Select Panel:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlPanels" runat="server" AutoPostBack="True" CssClass="dropdownlist">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAssign" runat="server" Text="Assign Panel to Group" OnClick="btnAssign_Click" CssClass="btn-assign" />
            </div>
        </div>
    </form>
</body>
</html>
