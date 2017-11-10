﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace LibClases
{
    public class clsImplementos
    {
        #region "Atributos"
        private DropDownList objCboImplementos;
        private int iCodigo;
        private string strNombre;
        private string strDescripción;
        private int iCantidad;
        private string strError;
        private string strSQL;
        #endregion

        #region "Propiedades"

        public DropDownList ObjCboImplementos
        {
            get { return objCboImplementos; }
            set { objCboImplementos = value; }
        }
        public int ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public string StrNombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        public string StrDescripción
        {
            get { return strDescripción; }
            set { strDescripción = value; }
        }

        public int ICantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }
        public string StrError
        {
            get { return strError; }
            set { strError = value; }
        }
        public string StrSQL
        {
            get { return strSQL; }
            set { strSQL = value; }
        }
     
        #endregion


        #region "Metodos"
        public bool Validar()
        {
            if (string.IsNullOrEmpty(strDescripción))
            {
                strError = "No definió la descripción";
                return false;
            }
            if (string.IsNullOrEmpty(strNombre))
            {
                strError = "No definió el nombre del implemento";
                return false;
            }
            if (ICantidad == 0)
            {
                strError = "No definió la cantidad o ingreso un número erroneo";
                return false;
            }
            return true;
        }

  /*      public bool Actualizar()
        {
            if (Validar())
            {
                //Debe grabar en la base de datos
                //Se debe agregar una referencia a la librería: libComunes
                //y agregar el using en la libreria
                //Creamos la instancia de la clase conexion
                clsConexion oConexion = new clsConexion();

                //Debemos crear la instrucción SQL
                strSQL = "UPDATE tblEmpleado " +
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
        }*/

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
                strSQL = "INSERT INTO [DBHosteria_Tesoro].[dbo].[Implementos]([Descripcion],[Nombre],[Cantidad])     VALUES('" + strDescripción + "','" + strNombre + "','" +
                             iCantidad + "')";

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

       /* public bool Consultar()
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
                          "FROM     tblEmpleado " +
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
        */
        public bool LlenarCombo()
        {
            //Validamos que nos envien el objeto combo
            if (objCboImplementos == null)
            {
                strError = "No definió el combo de empleado";
                return false;
            }
            //Defino la instrucción sql
            strSQL = "SELECT [IdImplementos] "+
      ",[Descripcion]"+
      ",[Nombre]"+
      ",[Cantidad]"+
  "FROM [DBHosteria_Tesoro].[dbo].[Implementos]";

            //Creamos una instancia del objeto combo
            clsCombo oCombo = new clsCombo();

            //Definimos las propiedades de combo: combo, sql, nombre tabla
            //columna de texto y columna de valor
            oCombo.SQL = strSQL;
            oCombo.cboGenericoWeb = objCboImplementos;
            oCombo.NombreTabla = "Implementos";
            oCombo.ColumnaTexto = "Nombre";
            oCombo.ColumnaValor = "IdImplementos";

            //Invocamos el metodo de llenar combo
            if (oCombo.LlenarComboWeb())
            {
                //Se llenó correctamente el combo web
                //Leer el combo lleno y asignarlo al combo de la clase
                objCboImplementos = oCombo.cboGenericoWeb;
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
