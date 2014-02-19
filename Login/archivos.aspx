<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="archivos.aspx.cs" Inherits="Login.archivos" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Login - Mis Archivos</title>
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
                      "<li><a href=\"administracion.aspx\"><u>" + Session["nombreUsuario"] + "</u></a></li>" +
                      "<li><a href=\"index.aspx\"><u>Inicio</u></a></li>");
              }
            %>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div class="pagina">
        <h2>Mis archivos</h2>
        <br />
        <h3>Agregar Archivo</h3>
        <form id="form1" runat="server">

            <asp:FileUpload ID="ArcFSubirArchivo"
                runat="server"></asp:FileUpload>
            <asp:Button ID="ArcBSubirArchivo"
                Text="Subir archivo"
                runat="server"></asp:Button>

            <hr />

            <asp:Label ID="ArcLEstatus"
                runat="server">
            </asp:Label>
        </form>
        <br />
        <h3>Archivos subidos</h3>
        <%
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("data source=localhost;user id=publico;password=12345678");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("dbo.test_GetFiles");
                cmd.Parameters.Add("@owner", System.Data.SqlDbType.VarChar).Value = Session["correoUsuario"];
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                System.Data.DataTable tabla = new System.Data.DataTable();
                tabla.Load(reader);
                reader.Close();
                con.Close();
                if (tabla.Rows.Count == 0)
                {
                    Response.Write("<b>No se han subido archivos</b>");
                }
                else if (tabla.Rows != null)
                {
                    for (int i = 0; i < tabla.Rows.Count; i++)
                    {
                        Response.Write("<a href=\"bajaArchivo.aspx?id=" + tabla.Rows[i][0] + "\">" + tabla.Rows[i][1] + "</'a><br/>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0120 ");
            }
        %>
    </div>
</body>
</html>
