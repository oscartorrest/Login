<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperar.aspx.cs" Inherits="Login.WebForm8" EnableSessionState="true" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login - Recuperación de Contraseña</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="encabezado">
        <h1 class="titulo">Nombre del Sitio</h1>
        <ul class="menu">
            <li><a href="acceso.aspx"><u>Acceder</u></a></li>
            <li><a href="registro.aspx"><u>Registrar</u></a></li>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div class="pagina">
        <h2>Recuperación de contraseña</h2>
        <form runat="server">
            <asp:TextBox ID="OlvTBCorreo" runat="server" MaxLength="50"></asp:TextBox><br />
            <asp:Label ID="OlvLMensaje" runat="server"><b>Escribe 
            el correo electrónico de tu cuenta y 
            te mandaremos a ese correo tu contraseña.</b></asp:Label><br />
            <br />
            <asp:Button ID="OlvBEnviar" runat="server" Text="Enviar" />
        </form>
    </div>
</body>
</html>
