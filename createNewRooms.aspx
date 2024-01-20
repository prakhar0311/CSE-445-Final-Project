<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createNewRooms.aspx.cs" Inherits="Hotel_Application_445.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Room Staff</title>
<style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
    }

    #form1 {
        background-color: #fff;
        width: 400px;
        margin: 50px auto;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h2 {
        color: #333;
    }

    label {
        display: block;
        margin: 10px 0 5px;
        color: #555;
    }

    input[type="text"], input[type="number"] {
        width: 100%;
        padding: 8px;
        margin: 5px 0;
        box-sizing: border-box;
    }

    textarea {
        width: 100%;
        padding: 8px;
        margin: 5px 0;
        box-sizing: border-box;
    }

    input[type="button"] {
        background-color: #4caf50;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

    input[type="button"]:hover {
        background-color: #45a049;
    }

    input[type="button"], input[type="button"]:hover {
        margin-top: 10px;
    }

    a {
        color: #4caf50;
        text-decoration: none;
        margin-left: 10px;
    }

    a:hover {
        color: #45a049;
    }

    .custom-button {
        background-color: #4caf50;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

    .custom-button-danger {
        background-color: #d9534f;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    } .back-button {
            position: absolute;
            top: 10px;
            left: 10px;
            color: #4caf50;
            text-decoration: none;
            font-size: 16px;
        }

        .back-button:hover {
            color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Back button -->
            <a href="javascript:history.back()" class="back-button">&#9665; Back</a>

            <h2>Add New Room Staff</h2>
            <label for="txtRoomType">Room Type:</label>
            <input type="text" id="txtRoomType" runat="server" />

            <label for="txtRoomQuantity">Room Quantity:</label>
            <input type="number" id="txtRoomQuantity" runat="server" />

            <label for="txtRoomDescription">Room Description:</label>
            <textarea id="txtRoomDescription" runat="server"></textarea>

            <label for="txtRoomCost">Room Cost:</label>
            <input type="number" id="txtRoomCost" runat="server" />

            <asp:Button ID="btnAddRoom" runat="server" Text="Add New Room" OnClick="btnAddRoom_Click" CssClass="custom-button" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="custom-button custom-button-danger" />
        </div>
    </form>
</body>
</html>
