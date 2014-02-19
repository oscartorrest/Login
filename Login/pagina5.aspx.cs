﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se establece que la última página, de las 5 de contenido, donde se estuvo es esta. 
            try
            {
                Session["anterior"] = "pagina5.aspx";
            }
            catch (Exception)
            {
                Response.Write("Se ha generado un problema inesperado, favor de volver a cargar la página más tarde");
                Response.Write("<br/>EP0108");
            }
        }
    }
}