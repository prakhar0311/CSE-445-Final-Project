<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsStaff.aspx.cs" Inherits="Hotel_Application_445.IsStaff" %>

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
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        #formContainer {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 300px;
            text-align: center;
        }

        h2 {
            color: #333;
        }

        label {
            display: block;
            margin: 10px 0 5px;
            color: #555;
        }

        input {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn {
            background-color: #4caf50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn-primary {
            background-color: #007bff;
        }

        .btn:hover {
            background-color: #45a049;
        }



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer">
            <h2>Welcome to the Staff Page</h2>

            <!-- Login Section -->
            <div>
                <label for="username">Username:</label>
                <input type="text" id="username" runat="server" />

                
                <asp:Button ID="btnNewStaff" runat="server" CssClass="btn btn-primary" Text="New Staff" OnClick="btnNewStaff_Click" />
                <asp:Button ID="btnLogout" runat="server" CssClass="btn" Text="Logout" OnClick="btnLogout_Click" />
            </div>
        </div>
    </form>
</body>
</html>
