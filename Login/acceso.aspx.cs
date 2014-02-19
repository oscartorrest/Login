﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Login
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Si ya hay un usuario conetcado se redirege a otra página. Si no, se agrega el listener al botón de iniciar sesión.
                if (Session["nombreUsuario"] != null)
                {
                    Response.Redirect((String)Session["anterior"]);
                }
                else
                {
                    AccBIniciarSes.Click += new EventHandler(this.Click_AccBIniciarSes);
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0100");
            }
        }

        protected void Click_AccBIniciarSes(Object sender, EventArgs e)
        {
            try
            {
                //Se comprueban las credenciales del usuario.
                //Si los datos ingresados son incorrectos la base de datos regresa un -1,
                //De lo contrario regresa un 1.
                SqlCommand cmd = new SqlCommand("dbo.test_ValidateCredentials");
                cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = AccTBCorreo.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = AccTBContrasena.Text;
                DataTable tabla = SQLHelper.runStoredProcedure(cmd);
                //Si no se encuentra el usuario se muestra el mensaje de error.
                //S sí se encuentra se carga al usuario.
                if (tabla.Rows==null)
                {
                    AccLMensaje.Visible = true;
                }
                else
                {
                    cargaUsuario(tabla.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    Response.Write("<br/>EP0114");
                }
                else
                {
                    Response.Write("<br/>EP0101");
                }
            }
        }

        private void cargaUsuario(Object respuesta)
        {
            String nombre = Convert.ToString(respuesta);
            AccLCorreo.Visible = false;
            AccLContrasena.Visible = false;
            AccTBContrasena.Visible = false;
            AccTBCorreo.Visible = false;
            AccLMensaje.Visible = true;
            AccBIniciarSes.Visible = false;
            AccHLOlvido.Visible = false;
            AccLMensaje.CssClass = "";
            AccLMensaje.Text = "<b>Estás conectad@ como \"" + nombre + "\"</b><br/><br/>"
                + "Volver al <a href=\"index.aspx\">Inicio</a>";
            //Se agregan los datos de sesion del usuario: su nombre y su correo.
            Session["nombreUsuario"] = nombre;
            Session["correoUsuario"] = AccTBCorreo.Text;
        }
    }
}
