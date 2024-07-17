<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllGradesOfFYPs.aspx.cs" Inherits="ViewAllGradesOfFYPs" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Group Grades</title>
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
            <h2>Group Grades</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="GroupID" HeaderText="Group ID" />
                    <asp:BoundField DataField="TotalMarksObtained" HeaderText="Total Marks Obtained" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
