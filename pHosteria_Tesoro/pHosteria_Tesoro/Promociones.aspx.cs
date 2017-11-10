using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;
namespace pHosteria_Tesoro
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarComboServicios();
            LlenarComboCabaña();
        }
        private void LlenarComboServicios()
        {
            clsServicio oServicios = new clsServicio();

            oServicios.ObjCboServicio = cboServicio;

            if (oServicios.LlenarCombo())
            {
                cboServicio = oServicios.ObjCboServicio;
            }
            else
            {
                lblError.Text = oServicios.StrError;
            }
            oServicios = null;
        }

        private void LlenarComboCabaña()
        {
            clsCabañas oCabaña = new clsCabañas();

            oCabaña.ObjCboCabaña = cboCabaña;

            if (oCabaña.LlenarCombo())
            {
                cboCabaña = oCabaña.ObjCboCabaña;
            }
            else
            {
                lblError.Text = oCabaña.StrError;
            }
            oCabaña = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            string strNombre;
            string strDescripción;
            int iServicio;
            int iCabaña;
            
            strNombre = txtNombre.Text;
            strDescripción = txtDescripcion.Text;
            iServicio = Convert.ToInt16(cboServicio.SelectedValue);
            iCabaña= Convert.ToInt16(cboCabaña.SelectedValue);
            
            clsPromocion oPromociones= new clsPromocion();

            oPromociones.StrDescripción = strDescripción;
            oPromociones.StrNombre = strNombre;
            oPromociones.ICabaña= iCabaña;
            oPromociones.IServicio= iServicio;
            
            if (oPromociones.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oPromociones.StrError;
            }

            oPromociones = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text="";
            txtDescripcion.Text= "";
            txtCantidad.Text = "";
            cboCabaña.SelectedIndex= -1;
            this.cboServicio.SelectedIndex = -1;
        }

    }
}