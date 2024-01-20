<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffDashBoard.aspx.cs" Inherits="Hotel_Application_445.StaffDashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #form1 {
            max-width: 600px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            text-align: center;
            text-decoration: none;
            background-color: #4CAF50;
            color: #fff;
            border-radius: 4px;
            cursor: pointer;
            margin-right: 10px;
        }

        #logoutButton {
            background-color: #d9534f;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Welcome to the Staff Dashboard</h2>
        <div>
            <a href="AddNewStaff.aspx" class="button">Add New Staff</a>
            <a href="createNewRooms.aspx" class="button">Add New Rooms</a>
            <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
