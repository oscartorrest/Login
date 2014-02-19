<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracion.aspx.cs" Inherits="Login.WebForm9" EnableSessionState="true" %>

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
            <%--Se cargan las opciones según si la sesión se ha iniciado o no--%>
            <%if (Session["nombreUsuario"] != null)
              {
                  Response.Write("<li><a href=\"salir.aspx\"><u>Salir</u></a></li>" +
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
        <h2>Administración usuario</h2>
        <form runat="server">
            <asp:TextBox ID="AdmTBNombre" runat="server" MaxLength="100"></asp:TextBox><br />
            <asp:Label ID="AdmLNombre" runat="server">Cambia nombre</asp:Label><br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="AdmTBAntigua" runat="server" TextMode="password" MaxLength="15"></asp:TextBox><br />
            <asp:Label ID="AdmLAntigua" runat="server">Antigua contraseña</asp:Label><br />
            <br />
            <br />
            <asp:TextBox ID="AdmTBNueva" runat="server" TextMode="password" MaxLength="15"></asp:TextBox><br />
            <asp:Label ID="AdmLNueva" runat="server">Nueva contraseña</asp:Label><br />
            <br />
            <asp:TextBox ID="AdmTBConfirma" runat="server" MaxLength="15" TextMode="password"></asp:TextBox><br />
            <asp:Label ID="AdmLConfirma" runat="server">Reescribe tu nueva contraseña</asp:Label><br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="AdmTBCorreo" runat="server" MaxLength="50"></asp:TextBox><br />
            <asp:Label ID="AdmLCorreo" runat="server">Cambia tu correo electrónico</asp:Label><br />
            <br />
            <br />
            <asp:Button ID="AdmBActualizar" runat="server" Text="Actualizar" />
        </form>
    </div>
</body>
</html>
