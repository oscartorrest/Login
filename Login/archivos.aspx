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
            <%if (Session["entradaUsuario"] != null)
              {
                  Response.Write( "<li><a href=\"salir.aspx\"><u>Salir</u></a></li>"+
                      "<li><a href=\"administracion.aspx\"><u>" + Session["entradaUsuario"] + "</u></a></li>" +
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
    <%
        using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("data source=localhost;user id=publico;password=12345678"))
      {
          using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("dbo.Get_Files", con))
          {
              cmd.CommandType = System.Data.CommandType.StoredProcedure;

              cmd.Parameters.Add("@owner", System.Data.SqlDbType.VarChar).Value = Session["correoUsuario"];

              con.Open();
              System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                           
              if (reader.HasRows)
              {
                  while (reader.Read())
                  {
                      Response.Write("<a href=\"bajaArchivo.aspx?id=" + reader.GetString(0) + "\">" + reader.GetString(1) + "</'a><br/>");
                  }
              }
              else
              {
                  Response.Write("<b>No se han subido archivos</b>");
              }
              reader.Close();
              con.Close();
          }
      }
         %>
    </div>
</body>
</html>
