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
    public partial class bajaArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Si no existe una sesión iniciada se redirige a la última página de contenido accedida o
                // en caso de haber accedido directamente con el link se redirige a la págian de acceso.
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
                //Si la sesión está iniciada entonces se procede con el proceso de descarga del archivo.
                else
                {
                    //El id se obtiene del GET, es recibido por medio del link seleccionado de la lista de archivos.
                    String archivo = Request.QueryString.Get("id");
                    //Se obtiene el nombre original y la dirección real del archivo.
                    SqlCommand cmd = new SqlCommand("dbo.test_GetFilePathAndName");
                    cmd.Parameters.Add("@idFile", SqlDbType.VarChar).Value = archivo;
                    DataTable tabla = SQLHelper.runStoredProcedure(cmd);
                    String path = Convert.ToString(tabla.Rows[0][0]);
                    String name = Convert.ToString(tabla.Rows[0][1]);
                    if (path.Equals(""))
                    {
                        Response.Write("<b>El archivo no existe</b>");
                    }
                    else
                    {
                        if (!File.Exists(Server.MapPath(path)))
                        {
                            Response.Write("<b>El archivo no existe</b>");
                        }
                        //Si el path no está vacío y sí existe se decarga el archivo.
                        else
                        {
                            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                            response.ClearContent();
                            response.Clear();
                            String extension = Path.GetExtension(path);
                            if (extension.Equals("xlsx"))
                            {
                                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            }
                            response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(name) + ";");
                            response.TransmitFile(Server.MapPath(path));
                            response.Flush();
                            response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                if (ex is InvalidOperationException || ex is SqlException || ex is ConfigurationErrorsException)
                {
                    Response.Write("<br/>EP0125");
                }
                else
                {
                    Response.Write("<br/>EP0126");
                }
            }
        }
    }
}