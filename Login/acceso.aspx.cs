﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["entradaUsuario"] != null)
            {
                Response.Redirect(Convert.ToString(Session["anterior"]));
            }
            else
            {
                AccBIniciarSes.Click += new EventHandler(this.Click_AccBIniciarSes);
            }
        }

        protected void Click_AccBIniciarSes(Object sender, EventArgs e)
        {
            SqlConnection conexion = Helper.GetConnection("data source=localhost;user id=publico;password=12345678");
            SqlCommand comando = Helper.GetCommand(conexion, "EXEC dbo.Valida_Datos @correo ='"
                + AccTBCorreo.Text +
                "', @contrasena='"
                + AccTBContrasena.Text +
                "';", System.Data.CommandType.Text);
            Object respuesta = comando.ExecuteScalar();
            try
            {
                int num = Convert.ToInt32(respuesta);
                if (num == -1)
                {
                    AccLMensaje.Visible = true;
                }
                else
                {
                    cargaUsuario(respuesta);
                }

            }
            catch (Exception)
            {
                cargaUsuario(respuesta);
            }
        }
        private void cargaUsuario(Object respuesta)
        {
            AccLCorreo.Visible = false;
            AccLContrasena.Visible = false;
            AccTBContrasena.Visible = false;
            AccTBCorreo.Visible = false;
            AccLMensaje.Visible = true;
            AccBIniciarSes.Visible = false;
            AccHLOlvido.Visible = false;
            AccLMensaje.CssClass = "";
            AccLMensaje.Text = "<b>Estás conectad@ como \"" + Convert.ToString(respuesta) + "\"</b><br/><br/>"
                + "Volver al <a href=\"index.aspx\">Inicio</a>";
            Session["entradaUsuario"] = Convert.ToString(respuesta);
            Session["correoUsuario"] = AccTBCorreo.Text;
        }
    }
}
