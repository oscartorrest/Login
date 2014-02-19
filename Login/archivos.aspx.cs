using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class archivos : System.Web.UI.Page
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
                    ArcBSubirArchivo.Click += new EventHandler(this.Click_ArcBSubirArchivo);
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0121");
            }
        }

        public void Click_ArcBSubirArchivo(object sender, EventArgs e)
        {
            try
            {
                // Si sí se seleccionó un archivo, se agrega primero a la base de datos,
                //  la base de datos regresa el id, el cual será el nombre del archivo.
                if (ArcFSubirArchivo.HasFile)
                {
                    String nombre = ArcFSubirArchivo.FileName;
                    String correo = Convert.ToString(Session["correoUsuario"]);
                    SqlCommand cmd = new SqlCommand("dbo.test_AddFile");
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = nombre;
                    DataTable tabla = SQLHelper.runStoredProcedure(cmd);
                    String id = Convert.ToString(tabla.Rows[0][0]);
                    String carpetaUsuario = Server.MapPath("archivos/" + Session["correoUsuario"]);
                    Directory.CreateDirectory(carpetaUsuario);
                    ArcFSubirArchivo.PostedFile.SaveAs(carpetaUsuario + "/"
                    + id + Path.GetExtension(nombre));
                    ArcLEstatus.Text = "Se ha subido el archivo " + nombre;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    Response.Write("<br/>EP0123");
                }
                else
                {
                    Response.Write("<br/>EP0124");
                }
            }
        }
    }
}