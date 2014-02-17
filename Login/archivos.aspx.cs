using System;
using System.Collections.Generic;
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
        }
    }
}