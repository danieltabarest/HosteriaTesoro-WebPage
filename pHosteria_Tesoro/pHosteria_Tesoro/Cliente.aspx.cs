using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace pHosteria_Tesoro
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string strDocumento, strNombre, strPrimerApellido, strSegundoApellido;
            string strDireccion;

            strDocumento = txtDocumento.Text;
            strNombre = txtNombre.Text;
            strPrimerApellido = txtPrimerApellido.Text;
            strSegundoApellido = txtSegundoApellido.Text;
            strDireccion = txtDireccion.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = strDocumento;
            oCliente.Nombre = strNombre;
            oCliente.PrimerApellido = strPrimerApellido;
            oCliente.SegundoApellido = strSegundoApellido;
            oCliente.Direccion = strDireccion;
            

            if (oCliente.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oCliente.Error;
            }

            oCliente = null;
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            string strDocumento;

            strDocumento = txtDocumento.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = strDocumento;

            if (oCliente.Consultar1())
            {
                txtNombre.Text = oCliente.Nombre;
                txtPrimerApellido.Text = oCliente.PrimerApellido;
                txtSegundoApellido.Text = oCliente.SegundoApellido;
                txtDireccion.Text = oCliente.Direccion;
                lblError.Text = "";
            }
            else
            {
                lblError.Text = oCliente.Error;

                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtDireccion.Text = "";
             
            }
            oCliente = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strDocumento, strNombre, strPrimerApellido, strSegundoApellido;
            string strDireccion;

            strDocumento = txtDocumento.Text;
            strNombre = txtNombre.Text;
            strPrimerApellido = txtPrimerApellido.Text;
            strSegundoApellido = txtSegundoApellido.Text;
            strDireccion = txtDireccion.Text;
            

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = strDocumento;
            oCliente.Nombre = strNombre;
            oCliente.PrimerApellido = strPrimerApellido;
            oCliente.SegundoApellido = strSegundoApellido;
            oCliente.Direccion = strDireccion;
            

            if (oCliente.Actualizar())
            {
                lblError.Text = "Actualizó";
            }
            else
            {
                lblError.Text = oCliente.Error;
            }

            oCliente = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtDireccion.Text = "";
         
        }
 
    }
}