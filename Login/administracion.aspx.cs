using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            try
            {
                //Si no hay un usuario registrado se redirecciona a la última página de contenido.
                //Si el usuario entró directamente a esta página y no tiene una sesión entonces
                //Se le es enviado a la página de acceso.
                //En caso de ya tener una sesión iniciada se agrega el event handler al botón.
                if (Session["nombreUsuario"] == null)
                {
                    if (Session["anterior"] != null)
                    {
                        Response.Redirect(Convert.ToString(Session["anterior"]));
                    }
                    else
                    {
                        Response.Redirect("acceso.aspx");
                    }
                }
                else
                {
                    AdmBActualizar.Click += new EventHandler(this.Click_AdmBActualizar);
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0115");
            }
        }

        private void Click_AdmBActualizar(object sender, EventArgs e)
        {
            try
            {
                //Si los campos no estpan vacíos se comeinza el proceso actualización de cada uno de ellos en
                // la base de datos.
                if (!AdmTBCorreo.Text.Equals(""))
                {
                    actualizaCorreo(AdmTBCorreo.Text);
                }

                //Se hace una revisión extra para saber si la contraseña y la contraseña de
                // actualización son iguales.
                if (!AdmTBNueva.Text.Equals("") && AdmTBNueva.Text.Equals(AdmTBConfirma.Text))
                {
                    actualizaContrasena(AdmTBAntigua.Text, AdmTBNueva.Text);
                }
                else
                {
                    AdmLConfirma.Text = "Asegurese de repetir correctamente la contraseña nueva";
                    AdmLConfirma.CssClass = "error";
                }

                if (!AdmTBNombre.Text.Equals(""))
                {
                    actualizaNombre(AdmTBNombre.Text);
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    AdmLNombre.Text = Convert.ToString(Session["correoUsuario"]) + "Hubo con error en la conexión a la base de datos. Intente más tarde";
                    AdmLNombre.CssClass = "error";
                }
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0116");
            }
        }


        private void actualizaNombre(String nombre)
        {
            SqlCommand cmd = new SqlCommand("dbo.test_ChangeName");
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = Session["correoUsuario"];
            cmd.Parameters.Add("@newName", SqlDbType.VarChar).Value = nombre;
            DataTable tabla = SQLHelper.runStoredProcedure(cmd);
            int respuesta = Convert.ToInt32(tabla.Rows[0][0]);
            if (respuesta == 1)
            {
                Session["nombreUsuario"] = nombre;
                AdmLNombre.Text = "<b>Tu nombre ha sido actualizado</b>";
                AdmLNombre.CssClass = "";
            }
        }

        private void actualizaCorreo(String correo)
        {
            SqlCommand cmd = new SqlCommand("dbo.test_ChangeMail");
            cmd.Parameters.Add("@newMail", SqlDbType.VarChar).Value = correo;
            cmd.Parameters.Add("@oldMail", SqlDbType.VarChar).Value = Session["correoUsuario"];
            DataTable tabla = SQLHelper.runStoredProcedure(cmd);
            int respuesta = Convert.ToInt32(tabla.Rows[0][0]);
            if (respuesta == 1)
            {
                Session["correoUsuario"] = correo;
                AdmLCorreo.Text = "El correo ha sido registrado";
                AdmLCorreo.CssClass = "";
            }
            else
            {
                AdmLCorreo.Text = "El correo ya está registrado con otra cuenta.";
                AdmLCorreo.CssClass = "error";
            }
        }

        private void actualizaContrasena(String antigua, String nueva)
        {
            SqlCommand cmd = new SqlCommand("dbo.test_ChangePassword");
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = Session["correoUsuario"];
            cmd.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = nueva;
            cmd.Parameters.Add("@oldPassword", SqlDbType.VarChar).Value = antigua;
            DataTable tabla = SQLHelper.runStoredProcedure(cmd);
            int respuesta = Convert.ToInt32(tabla.Rows[0][0]);
            if (respuesta == -1)
            {
                AdmLAntigua.Text = "La contraseña antigua es incorrecta.";
                AdmLAntigua.CssClass = "error";
            }
            else 
            {
                AdmLAntigua.Text = "<b>Tu contraseña ha sido actualizada</b>";
                AdmLAntigua.CssClass = "";
            }
        }
    }
}