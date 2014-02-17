using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["entradaUsuario"] == null) 
            {
                Response.Redirect(Convert.ToString(Session["anterior"]));
            }
            else 
            {
                AdmBActualizar.Click += new EventHandler(this.Click_AdmBActualizar);
            }
        }

        private void Click_AdmBActualizar(object sender, EventArgs e)
        {
            if (!AdmTBCorreo.Text.Equals("") && !AdmTBCorreo.Text.Equals("-1"))
            {
                actualizaCorreo(AdmTBCorreo.Text);
            }

            if (AdmTBNueva.Text.Equals(AdmTBConfirma.Text)&& !AdmTBNueva.Text.Equals("-1")) 
            {
                actualizaContrasena(AdmTBAntigua.Text,AdmTBNueva.Text);
            } 
            else
            {
                AdmLConfirma.Text = "Asegurese de repetir correctamente la contraseña nueva";
                AdmLConfirma.CssClass = "error";
            }

            if (!AdmTBNombre.Text.Equals("") && !AdmTBNombre.Text.Equals("-1")) 
            {
                actualizaNombre(AdmTBNombre.Text);
            }
        }

        private void actualizaNombre(String nombre)
        {
            int respuesta = ejecucionSimple("EXEC dbo.Cambia_Nombre @correo='"
                +Session["correoUsuario"]+
            "', @nombreNuevo='"+nombre+"';");
            if (respuesta == 0) 
            {
                AdmLNombre.Text = Convert.ToString(Session["correoUsuario"])+"Hubo con error en la conexión a la base de datos. Intente más tarde";
                AdmLNombre.CssClass = "error";
            }
            else 
            {
                Session["entradaUsuario"] = nombre;
            }
        }

        private void actualizaCorreo(String correo) 
        {
            int respuesta = ejecucionSimple("EXEC dbo.Cambia_Correo @correoNuevo='"
                + correo + "', @correoAntiguo='" + Session["correoUsuario"] + "';");
            if (respuesta == 0)
            {
                AdmLCorreo.Text = "Hubo con error en la conexión a la base de datos. Intente más tarde";
                AdmLCorreo.CssClass = "error";
            }
            else if (respuesta == 1)
            {
                Session["correoUsuario"] = correo;
            }
            else 
            {
                AdmLCorreo.Text = "El correo ya está registrado con otra cuenta.";
                AdmLCorreo.CssClass = "error";
            }
        }

        private void actualizaContrasena(String antigua, String nueva)
        {
            int respuesta = ejecucionSimple("EXEC dbo.Cambia_Contrasena @correo='"
                +Session["correoUsuario"]+"',@contrasenaNueva='"
                +nueva+"',@contrasenaAntigua='"+antigua+"';");
            if (respuesta == 0)
            {
                AdmLCorreo.Text = "Hubo con error en la conexión a la base de datos. Intente más tarde";
                AdmLCorreo.CssClass = "error";
            }
            else if (respuesta == -1)
            {
                AdmLAntigua.Text = "La contraseña antigua es incorrecta.";
                AdmLAntigua.CssClass = "error";
            }
        }

        private int ejecucionSimple(String commando) 
        {
            SqlConnection conexion = Helper.GetConnection("data source=localhost;user id=publico;password=12345678");
            SqlCommand comando = Helper.GetCommand(conexion,commando, System.Data.CommandType.Text);
            try
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception) 
            {
                return 0;
            }
        }
    }
}