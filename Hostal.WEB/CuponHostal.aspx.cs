using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostal.NEGOCIO;
using System.Web.Services;

namespace Hostal.WEB
{
    public partial class CuponHostal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pdfUrl = "data:application/pdf;base64," + (string)Session["cupon"];

            DateTime fecha = DateTime.Today;
            //pdfUrl = pdfUrl + "/" + fecha.ToShortDateString() +".pdf";
            pdfPreview.Attributes.Add("src", pdfUrl);

        }
    }
}