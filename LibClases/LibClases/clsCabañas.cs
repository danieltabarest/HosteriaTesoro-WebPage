using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;


namespace LibClases
{
   public class clsCabañas
    {
        #region "Atributos"
       private DropDownList objCboCabaña;
        private int iCodigo;
        private string strNombre;
        private string strDescripción;
        private int iTarifa;
        private int iServicio;
        private int iImplemento;
        private string strError;
        private string strSQL;
        #endregion

        #region "Propiedades"

        public DropDownList ObjCboCabaña
        {
            get { return objCboCabaña; }
            set { objCboCabaña = value; }
        }
        public int IServicio
        {
          get { return iServicio; }
          set { iServicio = value; }
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

        public int IImplemento
        {
            get { return iImplemento; }
            set { iImplemento = value; }
        }
        public int ITarifa
        {
            get { return iTarifa; }
            set { iTarifa = value; }
        }
        public string StrError
        {
            get { return strError; }
            
        }
        public string StrSQL
        {
            get { return strSQL; }
            set { strSQL = value; }
        }
     
        #endregion

        #region "Metodos"
        
          private bool Validar()
        {
            if (string.IsNullOrEmpty(strDescripción))
            {
                strError = "No definió la descripción";
                return false;
            }
            if (string.IsNullOrEmpty(strNombre))
            {
                strError = "No definió el nombre de la cabaña";
                return false;
            }
            
            if (iImplemento==0)
            {
                strError = "No definió implementos";
                return false;
            }
            if (iServicio== 0)
            {
                strError = "No definió el servicio";
                return false;
            }
            if (iTarifa== 0)
            {
                strError = "No definió la tarifa";
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
                strSQL = "UPDATE [DBHosteria_Tesoro].[dbo].[Cabaña]" +
                              " SET [IdCabaña] = " + iCodigo+ ", " +
                                         "[IdServicio] = " + iServicio + ", " +
                                         "[IdTarifa] = " + iTarifa+ ", " +
                                         "[IdImplementos] = " + iImplemento+ ", " +
                                         "[Descripcion] = '" + strDescripción + "' " +
                              "WHERE   [IdCabaña] = " + iCodigo+ "";

                
  

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
                strSQL = "INSERT INTO [DBHosteria_Tesoro].[dbo].[Cabaña]([IdServicio],[IdTarifa],[IdImplementos],[Descripcion],[Nombre])VALUES" +
           "(" + iServicio + "," +
                             iTarifa+ "," + iImplemento+ ",'" + strDescripción+ "','" +
                             strNombre+ "')";

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
            if (iCodigo == 0)
            {
                strError = "No definió el código de la cabaña";
                return false;
            }

            clsConexion oConexion = new clsConexion();

            strSQL = "SELECT [IdCabaña] "+
                          ",[IdServicio]"+
                          ",[IdTarifa]"+
                          ",[IdImplementos]"+
                          ",[Descripcion]"+
                          ",[Nombre]"+
                      "FROM [DBHosteria_Tesoro].[dbo].[Cabaña]"+
                          "WHERE    [IdCabaña] = " + iCodigo + "";

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

                    strNombre = oConexion.Reader.GetString(4);
                    strDescripción= oConexion.Reader.GetString(5);
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
            if (objCboCabaña == null)
            {
                strError = "No definió el combo de tarifas";
                return false;
            }
            //Defino la instrucción sql
            strSQL = "SELECT [IdCabaña],[IdServicio],[IdTarifa],[IdImplementos],[Descripcion],[Nombre] "+
                            " FROM [DBHosteria_Tesoro].[dbo].[Cabaña]"+
                          " ORDER BY	Nombre";

            //Creamos una instancia del objeto combo
            clsCombo oCombo = new clsCombo();

            //Definimos las propiedades de combo: combo, sql, nombre tabla
            //columna de texto y columna de valor
            oCombo.SQL = strSQL;
            oCombo.cboGenericoWeb = objCboCabaña;
            oCombo.NombreTabla = "Cabañas";
            oCombo.ColumnaTexto = "Nombre";
            oCombo.ColumnaValor = "IdCabaña";

            //Invocamos el metodo de llenar combo
            if (oCombo.LlenarComboWeb())
            {
                //Se llenó correctamente el combo web
                //Leer el combo lleno y asignarlo al combo de la clase
                objCboCabaña = oCombo.cboGenericoWeb;
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
