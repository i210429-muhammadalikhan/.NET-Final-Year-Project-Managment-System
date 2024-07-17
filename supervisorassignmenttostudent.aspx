<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisorassignmenttostudent.aspx.cs" Inherits="supervisorassignmenttostudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supervisor Assignment Page</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        h2 {
            color: #ffa500;
            margin-bottom: 20px;
        }
        
        #form1 {
            margin-top: 20px;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        .form-control {
            width: 100%;
            padding: 8px;
            font-size: 16px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
        }
        
        .btn {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #ffa500;
            color: #fff;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        
        .btn:hover {
            background-color: #ff7f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <h2>Select Supervisor for Project Group</h2>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="ddlSupervisors" runat="server" CssClass="form-control" DataTextField="full_name" DataValueField="supervisor_id">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAssignSupervisor" runat="server" Text="Assign Supervisor" OnClick="btnAssignSupervisor_Click" CssClass="btn" />
        </div>
    </form>
</body>
</html>
