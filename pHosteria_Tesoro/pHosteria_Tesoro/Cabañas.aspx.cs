using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace pHosteria_Tesoro
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        //Se debe crear una bandera con el combo que voy a utilizar como base para el combo
        //anidado y se inicia en true
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //En el primer llamado se vuelve false la bandera del combo
                
                LlenarComboTarifa();
                LlenarComboImplementos();
                LlenarComboServicios();

            }
            cboImplementos.SelectedValue = null;
            cboServicios.SelectedValue = null;
            cboTarifa.SelectedValue = null;
            
        }


        private void LlenarComboTarifa()
        {
            clsTarifas oTarifa = new clsTarifas();

            oTarifa.ObjCboTarifas = cboTarifa;

            if (oTarifa.LlenarCombo())
            {
                cboTarifa = oTarifa.ObjCboTarifas;
            }
            else
            {
                lblError.Text = oTarifa.StrError;
            }
            oTarifa = null;
            //Si lleno el combo de tipo producto, se convierte a true, para que llene el combo de producto
            
            
        }

        private void LlenarComboServicios()
        {
            clsServicio oServicios = new clsServicio();

            oServicios.ObjCboServicio = cboServicios;

            if (oServicios.LlenarCombo())
            {
                cboServicios = oServicios.ObjCboServicio;
            }
            else
            {
                lblError.Text = oServicios.StrError;
            }
            oServicios = null;
            //Si lleno el combo de tipo producto, se convierte a true, para que llene el combo de producto
            

        }

        private void LlenarComboImplementos()
        {
            clsImplementos oImplementos = new clsImplementos();

            oImplementos.ObjCboImplementos = cboImplementos;

            if (oImplementos.LlenarCombo())
            {
                cboImplementos = oImplementos.ObjCboImplementos;
            }
            else
            {
                lblError.Text = oImplementos.StrError;
            }
            oImplementos = null;
            //Si lleno el combo de tipo producto, se convierte a true, para que llene el combo de producto
            

        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
        
        string strNombre;
        string strDescripción;
        
            strNombre = txtNombre.Text;
            strDescripción = txtDescripcion.Text;

            clsCabañas oCabaña = new clsCabañas();

            oCabaña.StrDescripción = strDescripción;
            oCabaña.StrNombre = strNombre;
            oCabaña.IImplemento = Convert.ToInt16(cboImplementos.SelectedValue);
            oCabaña.IServicio = Convert.ToInt16(cboServicios.SelectedValue);
            oCabaña.ITarifa = Convert.ToInt16(cboTarifa.SelectedValue);


            if (oCabaña.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oCabaña.StrError;
            }
            

            oCabaña = null;
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strNombre;
            string strDescripción;
            strNombre = txtNombre.Text;
            strDescripción = txtDescripcion.Text;

            clsCabañas oCabaña = new clsCabañas();

            oCabaña.StrDescripción = strDescripción;
            oCabaña.StrNombre = strNombre;
            oCabaña.IImplemento = Convert.ToInt16(cboImplementos.SelectedValue);
            oCabaña.IServicio = Convert.ToInt16(cboServicios.SelectedValue);
            oCabaña.ITarifa = Convert.ToInt16(cboTarifa.SelectedValue);


            if (oCabaña.Actualizar())
            {
                lblError.Text = "Actualizó";
            }
            else
            {
                lblError.Text = oCabaña.StrError;
            }

            oCabaña = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            cboImplementos.SelectedValue = null;
            cboServicios.SelectedValue = null;
            cboTarifa.SelectedValue = null;
        }
 
    }
}