using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace pHosteria_Tesoro
{
    public partial class WebForm4 : System.Web.UI.Page
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

            clsImplementos oImplementos = new clsImplementos();

            oImplementos.StrDescripción = strDescripción;
            oImplementos.StrNombre = strNombre;
            oImplementos.ICantidad = Convert.ToInt16(txtCantidad.Text);


            if (oImplementos.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oImplementos.StrError;
            }


            oImplementos = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }

     /*   protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strNombre;
            string strDescripción;
            strNombre = txtNombre.Text;
            strDescripción = txtDescripcion.Text;

            clsCabañas oImplementos = new clsCabañas();

            oImplementos.StrDescripción = strDescripción;
            oImplementos.StrNombre = strNombre;
            oImplementos.IImplemento = Convert.ToInt16(cboImplementos.SelectedValue);
            oImplementos.IServicio = Convert.ToInt16(cboServicios.SelectedValue);
            oImplementos.ITarifa = Convert.ToInt16(cboTarifa.SelectedValue);


            if (oImplementos.Actualizar())
            {
                lblError.Text = "Actualizó";
            }
            else
            {
                lblError.Text = oImplementos.StrError;
            }

            oImplementos = null;
        }
 */

    }
}