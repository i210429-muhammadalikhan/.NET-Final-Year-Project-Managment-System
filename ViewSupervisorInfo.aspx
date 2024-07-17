<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSupervisorInfo.aspx.cs" Inherits="ViewSupervisorInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Supervisor Information</title>
    <style>
        /* Add your CSS styles here */
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        .supervisor-info {
            margin: 20px;
            padding: 20px;
            border: 1px solid #444;
            border-radius: 5px;
            background-color: #333;
        }
        
        .info-label {
            font-weight: bold;
            color: #ffa500;
            margin-right: 10px;
        }
        
        .info-label,
        .info-value {
            display: inline-block;
            margin-bottom: 5px;
        }
        
        .info-value {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="supervisor-info">
            <h2>Supervisor Information</h2>
            <div>
                <span class="info-label">Full Name:</span>
                <asp:Label ID="lblFullName" runat="server" CssClass="info-value"></asp:Label>
            </div>
            <div>
                <span class="info-label">Email:</span>
                <asp:Label ID="lblEmail" runat="server" CssClass="info-value"></asp:Label>
            </div>
            <div>
                <span class="info-label">Phone:</span>
                <asp:Label ID="lblPhone" runat="server" CssClass="info-value"></asp:Label>
            </div>
            <div>
                <span class="info-label">Registration ID:</span>
                <asp:Label ID="lblRegistrationId" runat="server" CssClass="info-value"></asp:Label>
            </div>
            <div>
                <span class="info-label">Department:</span>
                <asp:Label ID="lblDepartment" runat="server" CssClass="info-value"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
