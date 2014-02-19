﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="Login.WebForm7" EnableSessionState="true" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login - Acceso</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="encabezado">
        <h1 class="titulo">Nombre del Sitio</h1>
        <ul class="menu">
            <%--Se cargan las opciones según si la sesión se ha iniciado o no--%>
            <%if (Session["nombreUsuario"] == null)
              {
                  Response.Write("<li><a href=\"registro.aspx\"><u>Registrar</u></a></li>"
                  + "<li><a href=\"index.aspx\"><u>Inicio</u></a></li>");
              }
              else
              {
                  Response.Write("<li><a href=\"salir.aspx\"><u>Salir</u></a></li>" +
                      "<li><a href=\"administracion.aspx\"><u>" + Session["nombreUsuario"] + "</u></a></li>" +
                      "<li><a href=\"archivos.aspx\"><u>Mis Archivos</u></a></li>" +
                      "<li><a href=\"index.aspx\"><u>Inicio</u></a></li>");
              }
            %>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div class="pagina">
        <h2>Acceso</h2>
        <form runat="server">
            <asp:TextBox ID="AccTBCorreo" MaxLength="50" runat="server" /><br />
            <asp:Label ID="AccLCorreo" runat="server" Text="<b>Correo</b>" /><br />
            <br />
            <asp:TextBox ID="AccTBContrasena" MaxLength="15" TextMode="password" runat="server" /><br />
            <asp:Label ID="AccLContrasena" runat="server" Text="<b>Contraseña</b>" /><br />
            <asp:Label ID="AccLMensaje" runat="server" Visible="false" CssClass="error">Usuario o contraseña incorrectos</asp:Label><br />
            <asp:Button runat="server" Text="Iniciar Sesión" ID="AccBIniciarSes" />
            <br />
            <br />
            <asp:HyperLink ID="AccHLOlvido" runat="server" NavigateUrl="recuperar.aspx" Text="¿Olvidaste tu contraseña?" />

        </form>
    </div>
</body>
</html>
