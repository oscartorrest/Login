using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Elimina los datos de la sesión y redirige a la última 
                // de las 5 páginas de contenido donde se estuvo.
                Session["nombreUsuario"] = null;
                Session["correoUsuario"] = null;
                if (Session["anterior"] == null) 
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Redirect(Convert.ToString(Session["anterior"]));
                }
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0103");
            }
        }
    }
}