<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelCreationByFYPCommittee.aspx.cs" Inherits="PanelCreationByFYPCommittee" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Panel Creation Page</title>
    <style>
        body {
            background-color: #222;
            color: #fff;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        
        .welcome-message {
            color: #ffa500;
            font-size: 24px;
            margin-bottom: 20px;
        }
        
        .container {
            max-width: 800px;
            margin: 0 auto;
        }
        
        h1 {
            color: #ffa500;
            margin-bottom: 20px;
        }
        
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        
        .gridview th,
        .gridview td {
            padding: 10px;
            border: 1px solid #444;
        }
        
        .gridview th {
            background-color: #444;
            color: #fff;
            text-align: left;
        }
        
        .gridview td {
            background-color: #333;
            color: #fff;
        }
        
        .dropdownlist {
            width: 100%;
            padding: 8px;
            border: 1px solid #444;
            background-color: #333;
            color: #fff;
        }
        
        .dropdownlist option {
            background-color: #333;
            color: #fff;
        }
    </style>
</head>
<body>
    <div class="welcome-message">
        Welcome to Panel Creation Page
    </div>
    <form id="form1" runat="server" class="container">
        <div>
            <h1>Panel Members</h1>
            <asp:GridView ID="gvPanelMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="panel_member_id" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="department" HeaderText="Department" />
                    <asp:TemplateField HeaderText="Assign Panel">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPanels" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPanels_SelectedIndexChanged" CssClass="dropdownlist">
                                <asp:ListItem Value="">Select Panel</asp:ListItem>
                                <asp:ListItem Value="Panel1">Panel1</asp:ListItem>
                                <asp:ListItem Value="Panel2">Panel2</asp:ListItem>
                                <asp:ListItem Value="Panel3">Panel3</asp:ListItem>
                                <asp:ListItem Value="Panel4">Panel4</asp:ListItem>
                                <asp:ListItem Value="Panel5">Panel5</asp:ListItem>
                                <asp:ListItem Value="Panel6">Panel6</asp:ListItem>
                                <asp:ListItem Value="Panel7">Panel7</asp:ListItem>
                                <asp:ListItem Value="Panel8">Panel8</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
