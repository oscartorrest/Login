﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="Login.WebForm7" EnableSessionState="true"%>

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
            <%if (Session["entradaUsuario"] == null)
              {
                  Response.Write("<li><a href=\"pagina5.aspx\"><u>Registrar</u></a></li>"
                  + "<li><a href=\"index.aspx\"><u>Inicio</u></a></li>"); 
              }
              else 
              {
                  Response.Write( "<li><a href=\"salir.aspx\"><u>Salir</u></a></li>"+
                      "<li><a href=\"administracion.aspx\"><u>" + Session["entradaUsuario"] + "</u></a></li>");
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
            <asp:TextBox id="AccTBCorreo" MaxLength="50" runat="server"/><br />
            <asp:Label id="AccLCorreo" runat="server" text="<b>Correo</b>"/><br /><br />
            <asp:TextBox id="AccTBContrasena" MaxLength="15" TextMode="password" runat="server"/><br />
            <asp:Label id="AccLContrasena" runat="server" text="<b>Contraseña</b>"/><br />
            <asp:Label ID="AccLMensaje" runat="server" Visible="false" CssClass="error">Usuario o contraseña incorrectos</asp:Label><br />
            <asp:Button runat="server" text="Iniciar Sesión" id="AccBIniciarSes"/>
            <br/><br/>
            <asp:HyperLink id="AccHLOlvido" runat="server" NavigateUrl="recuperar.aspx" Text="¿Olvidaste tu contraseña?" />
    
        </form>
    </div>
    <div class="pie">
        <br />
        Prueba de login.
    </div>
</body>
</html>
