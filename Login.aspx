<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HGWebApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - Spotify</title>
    <style>        
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(120deg, #1db954, #191414);
            color: #fff;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form {
            background: #222;
            padding: 2rem;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.3);
            text-align: center;
            width: 100%;
            max-width: 400px;
        }

        h1 {
            font-size: 1.8rem;
            margin-bottom: 1.5rem;
            color: #1db954;
        }

        .login-button {
            display: inline-block;
            padding: 0.8rem 1.5rem;
            background: #1db954;
            color: #fff;
            font-size: 1rem;
            font-weight: bold;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background 0.3s ease;
            text-decoration: none;
        }

        .login-button:hover {
            background: #17a844;
        }

        .message-label {
            margin-top: 1rem;
            display: block;
            font-size: 0.9rem;
            color: #ddd;
        }

        @media (max-width: 768px) {
            form {
                padding: 1.5rem;
            }

            h1 {
                font-size: 1.5rem;
            }

            .login-button {
                padding: 0.7rem 1.2rem;
                font-size: 0.9rem;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Pruebas de conexión a Spotify</h1>
        <h2>Periferia IT</h2>
        <h3>Hernan Gonzalez - Pruebas Técnicas</h3>
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="login-button" Text="Login con Spotify" OnClick="btnLogin_Click" />
        <asp:Label ID="Label1" runat="server" CssClass="message-label"></asp:Label>
    </form>
</body>
</html>


