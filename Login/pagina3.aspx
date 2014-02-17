<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagina3.aspx.cs" Inherits="Login.WebForm3" EnableSessionState="true"%>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login - Página 3</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="encabezado">
        <h1 class="titulo">Nombre del Sitio</h1>
        <ul class="menu">
                        <%if (Session["entradaUsuario"] == null)
              {
                  Response.Write("<li><a href=\"acceso.aspx\"><u>Acceder</u></a></li>"
                  +"<li><a href=\"registro.aspx\"><u>Registrar</u></a></li>"); 
              }
              else 
              {
                  Response.Write( "<li><a href=\"salir.aspx\"><u>Salir</u></a></li>"+
                      "<li><a href=\"administracion.aspx\"><u>" + Session["entradaUsuario"] + "</u></a></li>"+
                      "<li><a href=\"archivos.aspx\">Mis Archivos</a></li>");
              }
            %>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div class="pagina">
            <ul id="menu" class="menu">
                <li><a href="index.aspx">Página 1</a></li>
                <li><a href="pagina2.aspx">Página 2</a></li>
                <li class="seleccionado"><a href="pagina3.aspx">Página 3</a></li>
                <li><a href="pagina4.aspx">Página 4</a></li>
                <li><a href="pagina5.aspx">Página 5</a></li>
            </ul>
        <div class="contenido">
            <br />
            Contenido de la página 3.
        </div>
    </div>
</body>
</html>
