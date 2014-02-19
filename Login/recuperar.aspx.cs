using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Data;

namespace Login
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Si hay una sesión iniciada se redirige a la última página con contenido en la que se estuvo.
                // En caso contrario se carga el event handler para el botón.
                if (Session["nombreUsuario"] != null)
                {
                    Response.Redirect(Convert.ToString(Session["anterior"]));
                }
                else
                {
                    OlvBEnviar.Click += new EventHandler(this.Click_OlvBEnviar);
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0109");
            }
        }

        protected void Click_OlvBEnviar(Object sender, EventArgs e)
        {
            try
            {
                // Se obtiene la contraseña del correo, si existe.
                SqlCommand cmd = new SqlCommand("dbo.test_GetPassword");
                cmd.Parameters.Add("@mail", System.Data.SqlDbType.VarChar).Value = OlvTBCorreo.Text;
                DataTable tabla = SQLHelper.runStoredProcedure(cmd);

                //Si la base de datos no regresó nada se marca error en el correo.
                //Si sí regresó la contraseña entonces se envía el correo.
                if (tabla.Rows == null)
                {
                    OlvLMensaje.Text = "El correo que ingresaste no está registrado en nyestro sitio.";
                    OlvLMensaje.CssClass = "error";
                }
                else
                {
                    mandaCorreo(Convert.ToString(tabla.Rows[0][0]));
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    Response.Write("La base de datos está en mantenimiento, favor de volver a cargar la página más tarde");
                    Response.Write("<br/>EP0110");
                }
                else
                {
                    Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                    Response.Write("<br/>EP0111");
                }
            }
        }
        private void mandaCorreo(Object respuesta)
        {
            SmtpClient smtpClient = null;
            MailMessage message = null;
            try
            {
                // Se carga el cliente SMTP con la información de la cuenta de correo.
                smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential("contacto@iexglobal.com", "j123abc#");
                message = new MailMessage();
                MailAddress fromAddress = new MailAddress("contacto@iexglobal.com");
                smtpClient.Host = "mail.iexglobal.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                //Se crea el mensaje.
                message.From = fromAddress;
                message.Subject = "Recuperación de contraseña";
                message.IsBodyHtml = true;
                message.Body = "<h3>Tu contraseña es: " + Convert.ToString(respuesta) + "</h3>";
                message.To.Add(OlvTBCorreo.Text);
                //Se manda el mensaje.
                smtpClient.Send(message);
                OlvLMensaje.Text = "Tu contraseña ha sido enviada a tu correo.";
            }
            catch (Exception)
            {
                OlvLMensaje.Text = "Tu contraseña no pudo ser enviada. Por favor intenta más tarde.";
                OlvLMensaje.CssClass = "error";
            }
            finally
            {
                OlvBEnviar.Visible = false;
                OlvTBCorreo.Visible = false;
                if (smtpClient != null)
                {
                    smtpClient.Dispose();
                }
                if (message != null)
                {
                    message.Dispose();
                }
            }
        }
    }
}