<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listAvailableRooms.aspx.cs" Inherits="Hotel_Application_445.listAvailableRooms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Room Booking</title>
    <style>
        /* Back button styles */
        .back-button {
            position: absolute;
            top: 10px;
            right: 10px; /* Changed from left to right */
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
            <!-- Back button moved to the top-right corner -->
            <a href="javascript:history.back()" class="back-button">&#9665; Back</a>

            <!-- Add your content for the listAvailableRooms.aspx page here -->
        </div>
    </form>
</body>
</html>
