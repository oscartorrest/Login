using System;
using System.Collections.Generic;
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
            if (Session["entradaUsuario"] == null)
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
                String archivo = Request.QueryString.Get("id");
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("data source=localhost;user id=publico;password=12345678"))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("dbo.Get_File_Path_And_Name", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idFile", System.Data.SqlDbType.VarChar).Value = archivo;

                        con.Open();
                        System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                        String path = "";
                        String name = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                path = reader.GetString(0);
                                name = reader.GetString(1);
                            }
                        }
                        if (path.Equals(""))
                        { 
                            Response.Write("<b>El archivo no existe</b>");
                        }
                        else
                        {
                            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                            response.ClearContent();
                            response.Clear();
                            String extension = Path.GetExtension(path);
                            if(extension.Equals("xlsx"))
                            {
                                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            }
                            response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(name) + ";");
                            response.TransmitFile(Server.MapPath(path));
                            response.Flush();
                            response.End();
                        }
                        reader.Close();
                        con.Close();
                    }
                }
            }
        }
    }
}