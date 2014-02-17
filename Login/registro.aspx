<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Login.WebForm6" EnableSessionState="true"%>

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
            <asp:TextBox id="RegTBNombre" MaxLength="100" runat="server"/><br />
            <asp:Label id="RegLNombre" runat="server" text="<b>Nombre</b>"/><br /><br />
            <asp:TextBox id="RegTBCorreo" MaxLength="50" runat="server"/><br />
            <asp:Label id="RegLCorreo" runat="server" text="<b>Correo</b>"/><br /><br />
            <asp:TextBox id="RegTBContrasena" MaxLength="15" TextMode="password" runat="server"/><br />
            <asp:Label id="RegLContrasena" runat="server" text="<b>Contraseña</b>"/><br /><br />
            <asp:TextBox id="RegTBRepContrasena" MaxLength="15" TextMode="password" runat="server"/><br />
            <asp:Label id="RegLRepContrasena" runat="server" text="<b>Repita Contraseña</b>"/><br /><br />
            <asp:Button runat="server" text="Registrar" id="RegBRegistrar"/>
        </form>
    </div>
</body>
</html>
