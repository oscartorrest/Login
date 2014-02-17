using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace Login
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["entradaUsuario"] != null)
            {
                Response.Redirect(Convert.ToString(Session["anterior"]));
            }
            else
            {
                OlvBEnviar.Click += new EventHandler(this.Click_OlvBEnviar);
            }
        }

        protected void Click_OlvBEnviar(Object sender, EventArgs e)
        {
            SqlConnection conexion = Helper.GetConnection("data source=localhost;user id=publico;password=12345678");
            SqlCommand comando = Helper.GetCommand(conexion, "EXEC dbo.Obten_Contrasena @correo ='"
                + OlvTBCorreo.Text +
                "';", System.Data.CommandType.Text);
            Object respuesta = comando.ExecuteScalar();
            try
            {
                int num = Convert.ToInt32(respuesta);
                if (num == -1)
                {
                    OlvLMensaje.Text = "El correo que ingresaste no está registrado en nyestro sitio.";
                    OlvLMensaje.CssClass = "error";
                }
                else
                {
                    mandaCorreo(respuesta);
                }
            }
            catch (Exception)
            {
                mandaCorreo(respuesta);
            }
        }
        private void mandaCorreo(Object respuesta)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential =
                    new NetworkCredential("contacto@iexglobal.com", "j123abc#");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("contacto@iexglobal.com");

                smtpClient.Host = "mail.iexglobal.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                message.From = fromAddress;
                message.Subject = "Recuperación de contraseña";
                message.IsBodyHtml = true;
                message.Body = "<h3>Tu contraseña es: " + Convert.ToString(respuesta) + "</h3>";
                message.To.Add(OlvTBCorreo.Text);
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
            }
        }
    }
}