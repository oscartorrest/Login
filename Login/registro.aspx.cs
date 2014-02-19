using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace Login
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private TextBox[] campos;
        private Label[] etiquetas;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Si ya hay una sesión abierta se redirecciona a la última página de cotenido activa.
                // Si no entonces se cargan los arreglos de cuadros de texto y labels,
                // además se vuelve a cargar e correo y el nombre de usuario si es que está página
                // está siendo cargada debido a un error en los requerimientos.
                if (Session["nombreUsuario"] != null)
                {
                    Response.Redirect(Convert.ToString(Session["anterior"]));
                }
                else
                {
                    campos = new TextBox[] { RegTBNombre, RegTBCorreo, RegTBContrasena, RegTBRepContrasena };
                    etiquetas = new Label[] { RegLNombre, RegLCorreo, RegLContrasena, RegLRepContrasena };
                    RegBRegistrar.Click += new EventHandler(this.Click_RegRRegistrar);
                    if (Session["correo"] != null)
                    {
                        RegTBCorreo.Text = Convert.ToString(Session["correo"]);
                        RegTBNombre.Text = Convert.ToString(Session["nombre"]);
                        Session["correo"] = null;
                        Session["nombre"] = null;
                    }
                    else
                    {
                        etiquetas[0].Text = "<b>Nombre</b>";
                        etiquetas[0].CssClass = "";
                        etiquetas[1].Text = "<b>Correo</b>";
                        etiquetas[1].CssClass = "";
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0112");
            }
        }

        protected void Click_RegRRegistrar(Object sender, EventArgs e)
        {
            try
            {
                // Se checa si todos los campos a llenar tienen texto.
                Boolean llenos = true;
                for (int i = 0; i < campos.Length; i++)
                {
                    if (campos[i].Text.Equals(""))
                    {
                        llenos = false;
                        etiquetas[i].CssClass = "error";
                    }
                    else
                    {
                        etiquetas[i].CssClass = "";
                    }
                }
                // Se checa si las contraseñas son iguales. Si no son iguales se marca el error y se toma como si los campos no estuvieran llenos.
                if (!campos[2].Text.Equals(campos[3].Text))
                {
                    etiquetas[3].Text = "<b>Las contraseñas deben de ser iguales</b>";
                    etiquetas[3].CssClass = "error";
                    llenos = false;
                }
                else
                {
                    etiquetas[3].Text = "<b>Repita contraseña</b>";
                    etiquetas[3].CssClass = llenos ? "" : "error";
                }
                // Si los campos están llenos s
                if (llenos)
                {
                    // Se checa si el usuario existen en la base de datos.
                    // Si el correo del usuario ya existe en la base de datos manda ésta regresa un 0
                    // significando que no se agregó el usuario a la base de datos. De lo contrario
                    // la base de datos regresa un 1 por un registro exitoso.
                    SqlCommand cmd = new SqlCommand("dbo.test_AddUser");
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = campos[0].Text;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = campos[1].Text;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = campos[2].Text;
                    DataTable tabla = SQLHelper.runStoredProcedure(cmd);
                    int num = Convert.ToInt32(tabla.Rows[0][0]);
                    if (num == 0)
                    {
                        etiquetas[1].Text = "<b>Este correo ya está asociado a una cuenta</b>";
                        etiquetas[1].CssClass = "error";
                        Session["correo"] = campos[1].Text;
                        Session["nombre"] = campos[0].Text;
                    }
                    else
                    {
                        for (int i = 0; i < campos.Length; i++)
                        {
                            campos[i].Visible = false;
                            etiquetas[i].Visible = false;
                        }
                        etiquetas[0].Visible = true;
                        etiquetas[0].Text = "<b>¡Tu cuenta a sido registrada!<br/>" +
                        "Puedes <a href=\"acceso.aspx\"><u>acceder</u></a> a tu cuenta" +
                        "<br/>O volver la página de <a href=\"index.aspx\"><u>inicio</u></a></b>";
                        RegBRegistrar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    for (int i = 0; i < campos.Length; i++)
                    {
                        campos[i].Visible = false;
                        etiquetas[i].Visible = false;
                    }
                    etiquetas[0].Visible = true;
                    etiquetas[0].Text = "<b>Hubo un error al comunicarnos con la base de datos, intente más tarde por favor</b>";
                    etiquetas[0].CssClass = "error";
                    RegBRegistrar.Visible = false;
                }
                else
                {
                    Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                    Response.Write("<br/>EP0113");
                }
            }
        }
    }
}