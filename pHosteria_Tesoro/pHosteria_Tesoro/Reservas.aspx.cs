using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibClases;
using System.Text.RegularExpressions;

namespace pHosteria_Tesoro
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        //Se debe crear una bandera con el combo que voy a utilizar como base para el combo
        //anidado y se inicia en true
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = System.DateTime.Now.ToString();
            if (Page.IsPostBack == false)
            {
                //En el primer llamado se vuelve false la bandera del combo
                LlenarComboPromociones();
                LlenarComboEmpleado();
                LlenarComboCabañas();
                this.lblFecha.Text = System.DateTime.Now.ToString();
                this.txtDescripcion.Visible = false;
                this.txtFechaIngreso.Visible = false;
                this.txtFechaSalida.Visible = false;
                cboCabaña.Visible = false;
                cboEmpleado.Visible = false;
                cboPromocion.Visible = false;
                this.ocultar.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            string strDocumento = txtCliente.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = strDocumento;

            if (oCliente.Consultar())
            {
                lblCliente.Text = oCliente.NombreCompleto;
                lblCliente.Visible = true;
                this.txtDescripcion.Visible = true;
                this.ocultar.Visible = true;
                this.txtFechaIngreso.Visible = true;
                this.txtFechaSalida.Visible = true;
                cboCabaña.Visible = true;
                cboEmpleado.Visible = true;
                cboPromocion.Visible = true;
                lblError.Text = "";
                grdDetalle.Visible = true;
                LlenarGridFactura();
            }
            else
            {
                lblError.Text = oCliente.Error;
                lblCliente.Text = "";
                this.txtDescripcion.Visible = false;
                this.txtFechaIngreso.Visible = false;
                this.txtFechaSalida.Visible = false;
                cboCabaña.Visible = false;
                cboEmpleado.Visible = false;
                cboPromocion.Visible = false;
                this.ocultar.Visible = false;
            }
            
        }

         protected void btnGrabar_Click(object sender, EventArgs e)
         {
            Regex RgFecNaci = new Regex(@"^\d{2}\/\d{2}\/\d{4}$");
            Regex RgFecNaciBenefic = new Regex(@"^\d{2}\/\d{2}\/\d{4}$");
            string fechaactual = DateTime.Now.ToString();
            if (txtFechaIngreso.Text == string.Empty)
            {
                lblError.Text= "El campo <b>Fecha de ingreso se encuentra vacío o no posee la adecuada";
            }
          else if (DateTime.Parse(this.txtFechaIngreso.Text) < DateTime.Parse(fechaactual))
	            {
		               lblError.Text= "El campo <b>Fecha de salida No puede ser menor que la del dia actual";
	            }
                        else if (Convert.ToDateTime(this.txtFechaSalida.Text) < DateTime.Now)
                        {
                            lblError.Text = "El campo <b>Fecha de salida No puede ser menor que la del dia actual";
                        }
            else if (Convert.ToDateTime(this.txtFechaSalida.Text) < DateTime.Parse(this.txtFechaIngreso.Text))
            {
                lblError.Text = "El campo <b>Fecha de salida No puede ser menor que la fecha de ingreso";
            }
                              else if (txtFechaSalida.Text == string.Empty)
                                {
                                    lblError.Text = "El campo <b>Fecha de salida se encuentra vacío o no posee la adecuada";
                                }
                                        else
                                        {
                                            GrabarReserva();
                                        }
	
                
        }
        
        private bool GrabarReserva()
        {
             System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("pt-PT");
            string strDocumento,Hora,Descripcion;
            Int32 intEmpleado, intCabaña;
            DateTime fechaIngreso, fechaSalida ;

            strDocumento = txtCliente.Text;
            intEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);
            intCabaña = Convert.ToInt32(cboCabaña.SelectedValue);
            fechaIngreso =  DateTime.ParseExact(txtFechaIngreso.Text, "dd/MM/yyyy", null);
            fechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null);
            Hora = DateTime.Now.TimeOfDay.ToString();
            Descripcion = txtDescripcion.Text;

            clsReservas oReservas = new clsReservas();

            oReservas.StrDescripción = Descripcion;
            oReservas.ICliente = Convert.ToInt16(strDocumento);
            oReservas.IEmpleado = intEmpleado;
            oReservas.ICabaña= intCabaña;
            oReservas.DtFechaIngreso1= fechaIngreso;
            oReservas.DtFechaSalida1= fechaSalida;
            oReservas.DtHora1= Hora;
            

            if (oReservas.Grabar())
            {
                lblError.Text = "Grabó";

               // lblNroReservas.Text = oReservas.NumeroReservas.ToString();
               // lblFecha.Text = oReservas.Fecha.ToString("yyyy/MM/dd HH:mm");
                //Se debe bloquear el cliente y el empleado
                txtCliente.Enabled = false;
                cboEmpleado.Enabled = false;

                oReservas = null;
                grdDetalle.Visible = true;
                LlenarGridFactura();
                return true;
            }
            else
            {
                lblError.Text = oReservas.StrError;
                oReservas = null;
                return false;
            }
        }
      
        private void LlenarComboEmpleado()
        {
            clsEmpleado oEmpleado = new clsEmpleado();

            oEmpleado.CboEmpleado = cboEmpleado;

            if (oEmpleado.LlenarCombo())
            {
                cboEmpleado = oEmpleado.CboEmpleado;
            }
            else
            {
                lblError.Text = oEmpleado.Error;
            }
            oEmpleado = null;
        }
        private void LlenarComboCabañas()
        {
            clsCabañas oCabañas = new clsCabañas();

            oCabañas.ObjCboCabaña= cboCabaña;

            if (oCabañas.LlenarCombo())
            {
                cboCabaña = oCabañas.ObjCboCabaña;
            }
            else
            {
                lblError.Text = oCabañas.StrError;
            }
            oCabañas = null;
        }

        private void LlenarComboPromociones()
        {
            clsPromocion oPromociones = new clsPromocion();

            oPromociones.ObjCboPromocion = cboPromocion;

            if (oPromociones.LlenarCombo())
            {
                cboPromocion = oPromociones.ObjCboPromocion;
            }
            else
            {
                lblError.Text = oPromociones.StrError;
            }
            oPromociones = null;
        }
        

        
        
        protected void btnCerrarFactura_Click(object sender, EventArgs e)
        {
            txtCliente.Enabled = true;
            txtCliente.Text = "";
            //lblNroReservas.Text = "";
            lblFecha.Text = "";
            cboEmpleado.Enabled = true;
            txtDescripcion.Text = "";
            lblCliente.Visible = false;
            txtCliente.Text = "";
            this.txtDescripcion.Visible = false;
            this.ocultar.Visible = false;
            this.txtFechaIngreso.Visible = false;
            this.txtFechaSalida.Visible = false;
            cboCabaña.Visible = false;
            cboEmpleado.Visible = false;
            cboPromocion.Visible = false;
            lblError.Text = "";
            grdDetalle.Visible = false;
            this.lblFecha.Text = System.DateTime.Now.ToString();
            


        }

        private void LlenarGridFactura()
        {
            Int32 intNumeroReservas;

            intNumeroReservas = Convert.ToInt32(txtCliente.Text);
            //Creamos una instancia de  Factura
            clsReservas oReservas = new clsReservas();

            oReservas.StrDocumento= intNumeroReservas.ToString();
            oReservas.GrdReservas = grdDetalle;

            if (oReservas.LlenarGrid())
            {
                //Lleno el combo
                grdDetalle = oReservas.GrdReservas;
            }
            else
            {
                lblError.Text = oReservas.StrError;
            }
            oReservas = null;
        }

    
        public bool ValidarFecha(string strDate)
        {

            DateTime date;
    

            if (DateTime.TryParseExact(strDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date))
            {

                return true;

            }

            else
            {

                return false;

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string strDocumento = txtCliente.Text;

            clsReservas oReserva = new clsReservas();
            if (string.IsNullOrEmpty(strDocumento))
            {
                lblError.Text = "Debe Consultar un cliente";
            }
            else
            {
                oReserva.ICliente = Convert.ToInt32(strDocumento);

                if (oReserva.Borrar())
                {
                    lblError.Text = "Se canceló la reservación";
                    lblCliente.Visible = false;
                    txtCliente.Text = "";
                    this.txtDescripcion.Visible = false;
                    this.ocultar.Visible = false;
                    this.txtFechaIngreso.Visible = false;
                    this.txtFechaSalida.Visible = false;
                    cboCabaña.Visible = false;
                    cboEmpleado.Visible = false;
                    cboPromocion.Visible = false;
                    grdDetalle.Visible = true;
                    LlenarGridFactura();

                }
                else
                {
                    lblError.Text = oReserva.StrError;

                }
            }
        }

        protected void cboCabaña_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}