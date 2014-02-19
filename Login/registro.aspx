<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Login.WebForm6" EnableSessionState="true" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login - Registro</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="encabezado">
        <h1 class="titulo">Nombre del Sitio</h1>
        <ul class="menu">
            <li><a href="index.aspx"><u>Inicio</u></a></li>
            <li><a href="acceso.aspx"><u>Acceder</u></a></li>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div class="pagina">
        <h2>Registro</h2>
        <form runat="server">
            <asp:TextBox ID="RegTBNombre" MaxLength="100" runat="server" /><br />
            <asp:Label ID="RegLNombre" runat="server" Text="<b>Nombre</b>" /><br />
            <br />
            <asp:TextBox ID="RegTBCorreo" MaxLength="50" runat="server" /><br />
            <asp:Label ID="RegLCorreo" runat="server" Text="<b>Correo</b>" /><br />
            <br />
            <asp:TextBox ID="RegTBContrasena" MaxLength="15" TextMode="password" runat="server" /><br />
            <asp:Label ID="RegLContrasena" runat="server" Text="<b>Contraseña</b>" /><br />
            <br />
            <asp:TextBox ID="RegTBRepContrasena" MaxLength="15" TextMode="password" runat="server" /><br />
            <asp:Label ID="RegLRepContrasena" runat="server" Text="<b>Repita Contraseña</b>" /><br />
            <br />
            <asp:Button runat="server" Text="Registrar" ID="RegBRegistrar" />
        </form>
    </div>
</body>
</html>
