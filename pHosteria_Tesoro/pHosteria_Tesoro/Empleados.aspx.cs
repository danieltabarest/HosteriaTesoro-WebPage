using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;

namespace pHosteria_Tesoro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string strDocumento, strNombre, strPrimerApellido, strSegundoApellido;
            string strDireccion, strTelefono;

            strDocumento = txtDocumento.Text;
            strNombre = txtNombre.Text;
            strPrimerApellido = txtPrimerApellido.Text;
            strSegundoApellido = txtSegundoApellido.Text;
            strDireccion = txtDireccion.Text;
            strTelefono = txtTelefono.Text;

            clsEmpleado oEmpleado= new clsEmpleado();

            oEmpleado.Documento = strDocumento;
            oEmpleado.Nombre = strNombre;
            oEmpleado.PrimerApellido = strPrimerApellido;
            oEmpleado.SegundoApellido = strSegundoApellido;
            oEmpleado.Direccion = strDireccion;
            oEmpleado.Telefono = strTelefono;

            if (oEmpleado.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oEmpleado.Error;
            }

            oEmpleado = null;
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            string strDocumento;

            strDocumento = txtDocumento.Text;

            clsEmpleado oEmpleado = new clsEmpleado();

            oEmpleado.Documento = strDocumento;

            if (oEmpleado.Consultar())
            {
                txtNombre.Text = oEmpleado.Nombre;
                txtPrimerApellido.Text = oEmpleado.PrimerApellido;
                txtSegundoApellido.Text = oEmpleado.SegundoApellido;
                txtDireccion.Text = oEmpleado.Direccion;
                txtTelefono.Text = oEmpleado.Telefono;

                lblError.Text = "";
            }
            else
            {
                lblError.Text = oEmpleado.Error;

                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
            }
            oEmpleado = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strDocumento, strNombre, strPrimerApellido, strSegundoApellido;
            string strDireccion, strTelefono;

            strDocumento = txtDocumento.Text;
            strNombre = txtNombre.Text;
            strPrimerApellido = txtPrimerApellido.Text;
            strSegundoApellido = txtSegundoApellido.Text;
            strDireccion = txtDireccion.Text;
            strTelefono = txtTelefono.Text;

            clsEmpleado oEmpleado = new clsEmpleado();

            oEmpleado.Documento = strDocumento;
            oEmpleado.Nombre = strNombre;
            oEmpleado.PrimerApellido = strPrimerApellido;
            oEmpleado.SegundoApellido = strSegundoApellido;
            oEmpleado.Direccion = strDireccion;
            oEmpleado.Telefono = strTelefono;

            if (oEmpleado.Actualizar())
            {
                lblError.Text = "Actualizó";
            }
            else
            {
                lblError.Text = oEmpleado.Error;
            }

            oEmpleado = null;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text= "";
            txtNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
 
    }
}