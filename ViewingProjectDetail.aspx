<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewingProjectDetail.aspx.cs" Inherits="ViewingProjectDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* General GridView Styling */
        #gvProjects {
            width: 80%;
            margin: 20px auto;
            border-collapse: collapse;
            font-family: Arial, sans-serif;
        }

        #gvProjects th, #gvProjects td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #gvProjects th {
            background-color: #f2f2f2;
            font-weight: bold;
        }

        /* Alternating Row Colors */
        #gvProjects tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        /* Hover Effect */
        #gvProjects tr:hover {
            background-color: #e9e9e9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="project_id" HeaderText="Project ID" />
                    <asp:BoundField DataField="leader_name" HeaderText="Leader Name" />
                    <asp:BoundField DataField="project_title" HeaderText="Project Title" />
                    <asp:BoundField DataField="project_description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>