using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace LibClases
{
    public class clsCliente
    {
        #region "Atributos"
        private DropDownList objCboEmpleado;
        private string strDocumento;
        private string strNombre;
        private string strPrimerApellido;
        private string strSegundoApellido;
        private string strDireccion;
        private string strTelefono;
        private string strSQL;
        private string strError;
        #endregion

        #region "Propiedades"
        public DropDownList CboCliente
        {
            get { return objCboEmpleado; }
            set { objCboEmpleado = value; }
        }
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        public string PrimerApellido
        {
            get { return strPrimerApellido; }
            set { strPrimerApellido = value; }
        }

        public string SegundoApellido
        {
            get { return strSegundoApellido; }
            set { strSegundoApellido = value; }
        }

        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        public string Direccion
        {
            get { return strDireccion; }
            set { strDireccion = value; }
        }

        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }

        public string NombreCompleto
        {
            get { return strNombre + " " + strPrimerApellido + " " + strSegundoApellido; }
        }

        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos"
        public bool Consultar()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "No definió el documento del cliente";
                return false;
            }

            strSQL = "SELECT       strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE " +
                         "FROM           Cliente " +
                         "WHERE        strDocumento_CLIE = '" + strDocumento + "'";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = strSQL;

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    strNombre = oConexion.Reader.GetString(0);
                    strPrimerApellido = oConexion.Reader.GetString(1);
                    strSegundoApellido = oConexion.Reader.GetString(2);

                    oConexion = null;
                    return true;
                }
                else
                {
                    strError = "No hay datos de cliente para el documento seleccionado";
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                strError = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool Actualizar()
        {
            if (Validar())
            {
                //Debe grabar en la base de datos
                //Se debe agregar una referencia a la librería: libComunes
                //y agregar el using en la libreria
                //Creamos la instancia de la clase conexion
                clsConexion oConexion = new clsConexion();

                //Debemos crear la instrucción SQL
                strSQL = "UPDATE [DBHosteria_Tesoro].[dbo].[Cliente] " +
                              "SET      [strNombre_CLIE] ='" + strNombre + "', " +
                                         "[strPrimerApellido_CLIE] = '" + strPrimerApellido + "', " +
                                         "[strSegundoApellido_CLIE] = '" + strSegundoApellido + "', " +
                                         "[strDireccion_CLIE] = '" + strDireccion + "' " +
                              "WHERE   [strDocumento_CLIE] = '" + strDocumento + "'";

                //Se debe pasar la propiedad sql al objeto
                oConexion.SQL = strSQL;

                //Ejecutamos la sentencia SQL
                if (oConexion.EjecutarSentencia())
                {
                    //Ejecuto correctamente: Grabo los datos, debo liberar memoria
                    //y retornar verdader
                    oConexion = null;
                    return true;
                }
                else
                {
                    //Hubo un error: Capturar el error, liberar y retornar
                    strError = oConexion.Error;
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "No definió el documento del cliente";
                return false;
            }
            if (string.IsNullOrEmpty(strNombre))
            {
                strError = "No definió el nombre del cliente";
                return false;
            }
            if (string.IsNullOrEmpty(strPrimerApellido))
            {
                strError = "No definió el primer apellido del cliente";
                return false;
            }
            if (string.IsNullOrEmpty(strDireccion))
            {
                strError = "No definió la dirección del cliente";
                return false;
            }
            
            return true;
        }


        public bool Grabar()
        {
            if (Validar())
            {
                //Debe grabar en la base de datos
                //Se debe agregar una referencia a la librería: libComunes
                //y agregar el using en la libreria
                //Creamos la instancia de la clase conexion
                clsConexion oConexion = new clsConexion();

                //Debemos crear la instrucción SQL
                strSQL = "INSERT INTO [DBHosteria_Tesoro].[dbo].[Cliente]"
           +"([strDocumento_CLIE]"
           +",[strNombre_CLIE]"
          +" ,[strPrimerApellido_CLIE]"
           +",[strSegundoApellido_CLIE]"
           +",[strDireccion_CLIE])"
     +"VALUES "
          +"('" + strDocumento + "','" + strNombre + "','" +
                             strPrimerApellido + "','" + strSegundoApellido + "','" + strDireccion + "'"+
                              ")";

                //Se debe pasar la propiedad sql al objeto
                oConexion.SQL = strSQL;

                //Ejecutamos la sentencia SQL
                if (oConexion.EjecutarSentencia())
                {
                    //Ejecuto correctamente: Grabo los datos, debo liberar memoria
                    //y retornar verdader
                    oConexion = null;
                    return true;
                }
                else
                {
                    //Hubo un error: Capturar el error, liberar y retornar
                    strError = oConexion.Error;
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Consultar1()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "No definió el documento del Cliente";
                return false;
            }

            clsConexion oConexion = new clsConexion();

            strSQL = "SELECT      strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE, strDireccion_CLIE "+
  " "+" FROM         dbo.Cliente"+
                          " WHERE    strDocumento_CLIE = '" + strDocumento + "'";

            //Se debe pasar la propiedad SQL al objeto conexion
            oConexion.SQL = strSQL;

            //Se invoca el método de consultar de la clase conexión
            if (oConexion.Consultar())
            {
                //Verificar si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Hay que invocar el método Read
                    oConexion.Reader.Read();

                    strNombre = oConexion.Reader.GetString(0);
                    strPrimerApellido = oConexion.Reader.GetString(1);
                    strSegundoApellido = oConexion.Reader.GetString(2);
                    strDireccion = oConexion.Reader.GetString(3);
                   

                    oConexion = null;
                    return true;
                }
                else
                {
                    //No hay datos, se debe generar un mensaje de error
                    strError = "El documento del cliente no existe en la base de datos";
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                //Hubo un error al consultar, se lee el error, se libera memoria y se retorna
                strError = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool LlenarCombo()
        {
            //Validamos que nos envien el objeto combo
            if (objCboEmpleado == null)
            {
                strError = "No definió el combo de cliente";
                return false;
            }
            //Defino la instrucción sql
            strSQL = "SELECT     strDocumento_CLIE, strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE, strDireccion_CLIE"+
                 " "+ "FROM         dbo.Cliente"+
                          "ORDER BY		strNombre_CLIE";

            //Creamos una instancia del objeto combo
            clsCombo oCombo = new clsCombo();

            //Definimos las propiedades de combo: combo, sql, nombre tabla
            //columna de texto y columna de valor
            oCombo.SQL = strSQL;
            oCombo.cboGenericoWeb = objCboEmpleado;
            oCombo.NombreTabla = "Cliente";
            oCombo.ColumnaTexto = "strNombre_CLIE";
            oCombo.ColumnaValor = "strDocumento_CLIE";

            //Invocamos el metodo de llenar combo
            if (oCombo.LlenarComboWeb())
            {
                //Se llenó correctamente el combo web
                //Leer el combo lleno y asignarlo al combo de la clase
                objCboEmpleado = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                //Hay error, se captura el error, se libera y se retorna false
                strError = oCombo.Error;
                oCombo = null;
                return false;
            }
        }

        #endregion
    }
}
