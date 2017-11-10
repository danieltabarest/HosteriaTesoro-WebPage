using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;
namespace pHosteria_Tesoro
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            string strNombre;
            string strDescripción;
            strNombre = txtNombre.Text;
            strDescripción = txtDescripcion.Text;
            clsServicio oServicios = new clsServicio();

            oServicios.StrDescripción = strDescripción;
            oServicios.StrNombre = strNombre;
            
            if (oServicios.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oServicios.StrError;
            }

            oServicios = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }
    }
}