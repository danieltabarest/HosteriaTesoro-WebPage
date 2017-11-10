using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;
using System.Globalization;
namespace pHosteria_Tesoro
{
    public partial class WebForm5 : System.Web.UI.Page
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

            clsTarifas oTarifas= new clsTarifas();
            if (this.txtValorUnitario.Text == "")
            {
                lblError.Text = "Debe ingresar un valor unitario";
            }
            else
            {


                oTarifas.StrDescripción = strDescripción;
                oTarifas.StrNombre = strNombre;


                oTarifas.FltValorUnitario = Convert.ToDouble(txtValorUnitario.Text);


                if (oTarifas.Grabar())
                {
                    lblError.Text = "Grabó";
                }
                else
                {
                    lblError.Text = oTarifas.StrError;
                }


                oTarifas = null;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtValorUnitario.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }

        
    }
}