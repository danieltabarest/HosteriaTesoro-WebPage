using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace LibClases
{
    public class clsEmpleado
    {
        #region "Atributos"
        private DropDownList objCboEmpleado;
        private string strDocumento;
        private string strNombre;
        private string strPrimerApellido;
        private string strSegundoApellido;
        private string strDireccion;
        private string strTelefono;
        private string strError;
        private string strSQL;

   
        #endregion

        #region "Propiedades"
        public DropDownList CboEmpleado
        {
            get { return objCboEmpleado; }
            set { objCboEmpleado = value; }
        }

        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
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

        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos"
        private bool Validar()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "No definió el documento del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strNombre))
            {
                strError = "No definió el nombre del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strPrimerApellido))
            {
                strError = "No definió el primer apellido del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strDireccion))
            {
                strError = "No definió la dirección del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strTelefono))
            {
                strError = "No definió el teléfono del empleado";
                return false;
            }
            return true;
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
                strSQL = "UPDATE Empleado " +
                              "SET      strNombre_EMPL ='" + strNombre + "', " +
                                         "strPrimerApellido_EMPL = '" + strPrimerApellido + "', " +
                                         "strSegundoApellido_EMPL = '" + strSegundoApellido + "', " +
                                         "strDireccion_EMPL = '" + strDireccion + "', " +
                                         "strTelefono_EMPL = '" + strTelefono + "' " +
                              "WHERE   strDocumento_EMPL = '" + strDocumento + "'";

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
                strSQL = "INSERT INTO Empleado (strDocumento_EMPL, strNombre_EMPL, " +
                             "strPrimerApellido_EMPL, strSegundoApellido_EMPL, strDireccion_EMPL, " +
                             "strTelefono_EMPL) " +
                             "VALUES('" + strDocumento + "','" + strNombre + "','" +
                             strPrimerApellido + "','" + strSegundoApellido + "','" + strDireccion + "','" +
                             strTelefono + "')";

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

        public bool Consultar()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "No definió el documento del empleado";
                return false;
            }

            clsConexion oConexion = new clsConexion();

            strSQL = "SELECT    strNombre_EMPL, strPrimerApellido_EMPL, " +
                                         "strSegundoApellido_EMPL, strDireccion_EMPL, " +
                                         "strTelefono_EMPL " +
                          "FROM     Empleado " +
                          "WHERE    strDocumento_EMPL = '" + strDocumento + "'";

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
                    strTelefono = oConexion.Reader.GetString(4);

                    oConexion = null;
                    return true;
                }
                else
                {
                    //No hay datos, se debe generar un mensaje de error
                    strError = "El documento del empleado no existe en la base de datos";
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
                strError = "No definió el combo de empleado";
                return false;
            }
            //Defino la instrucción sql
            strSQL = "SELECT [strDocumento_EMPL],[strNombre_EMPL],[strPrimerApellido_EMPL],[strSegundoApellido_EMPL],[strDireccion_EMPL],[strTelefono_EMPL] "+ 
        " FROM [DBHosteria_Tesoro].[dbo].[Empleado] " +
                          "ORDER BY		strNombre_EMPL";

            //Creamos una instancia del objeto combo
            clsCombo oCombo = new clsCombo();

            //Definimos las propiedades de combo: combo, sql, nombre tabla
            //columna de texto y columna de valor
            oCombo.SQL = strSQL;
            oCombo.cboGenericoWeb = objCboEmpleado;
            oCombo.NombreTabla = "Empleado";
            oCombo.ColumnaTexto = "strNombre_EMPL";
            oCombo.ColumnaValor = "strDocumento_EMPL";

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
