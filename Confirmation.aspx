<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="Hotel_Application_445.ConfirmationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #confirmation {
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

        span {
            font-weight: bold;
        }

        a {
            color: #4caf50;
            text-decoration: none;
            margin-left: 10px;
        }

        a:hover {
            color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="confirmation" runat="server">
            <h2>Confirmation Page</h2>
            <asp:Literal ID="litConfirmation" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back to Home" OnClick="btnBack_Click" CssClass="custom-button" />
        </div>
    </form>
</body>
</html>
