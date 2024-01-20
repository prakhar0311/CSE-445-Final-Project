<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication_HotelDashboard.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Dashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .container {
            margin-top: 50px;
        }

        h2 {
            text-align: center;
            color: #007bff;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            font-weight: bold;
        }

        .btn-primary,
        .btn-secondary,
        .btn-danger {
            width: 100%;
            margin-bottom: 10px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>Hotel Dashboard </h2>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <form id="addRoomForm" runat="server">
                    <div class="form-group">
                        <br />
                        <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" OnClick="btnAddRoom_Click" class="btn btn-primary" />
                        <br />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnManageReservation" runat="server" Text="Manage Reservation" OnClick="btnManageReservation_Click" class="btn btn-secondary" />
                        <br />
                    </div>
                    <div class="form-group">
                        <!-- Logout Button -->
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" class="btn btn-danger" />
                    </div>
                </form>
            </div>
        </div>

        <!-- Booking Management -->
        <div class="row justify-content-center mt-5">
            <div class="col-md-6">
                <!-- Add booking management code here -->
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</body>
</html>
