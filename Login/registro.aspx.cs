using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        TextBox[] campos;
        Label[] etiquetas;
        protected void Page_Load(object sender, EventArgs e)
        {
            campos = new TextBox[]
            {
                RegTBNombre,RegTBCorreo,RegTBContrasena,RegTBRepContrasena
            };
            etiquetas = new Label[]
            {
            RegLNombre,RegLCorreo,RegLContrasena,RegLRepContrasena
            };
            if (Session["entradaUsuario"] != null)
            {
                Response.Redirect(Convert.ToString(Session["anterior"]));
            }
            else
            {
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

        protected void Click_RegRRegistrar(Object sender, EventArgs e)
        {
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
            if (llenos)
           {
                SqlConnection conexion = Helper.GetConnection("data source=localhost;user id=publico;password=12345678");
                SqlCommand comando = Helper.GetCommand(conexion, "EXEC dbo.Agrega_Usuario @nombre='"
                    + campos[0].Text +
                    "', @correo='" +
                    campos[1].Text
                    + "', @contrasena='" +
                    campos[2].Text
                    + "';", System.Data.CommandType.Text);
                try
                {
                    int num = Convert.ToInt32(comando.ExecuteScalar());
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
                catch (Exception)
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

            }
        }

    }
}