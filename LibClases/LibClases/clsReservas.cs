using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace LibClases
{
    public class clsReservas
    {
        #region "Atributos"
        private DropDownList objCboReservas;
        private int iCodigo;
        private string strNombre;
        private string strDescripción;
        private string strDocumento;

        private string strPrimerApellido;
        private string strSegundoApellido;
        private GridView objGrdReservas;
        private int iCabaña;
        private int iCliente;
        private int iEmpleado;
        private DateTime DtFechaIngreso;
        private DateTime DtFechaSalida;
        private string DtHora;
        private string strError;
        private string strSQL;
        #endregion

        #region "Propiedades"
        public GridView GrdReservas
        {
            get { return objGrdReservas; }
            set { objGrdReservas = value; }
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

        public string StrDocumento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        public DateTime DtFechaIngreso1
        {
            get { return DtFechaIngreso; }
            set { DtFechaIngreso = value; }
        }
        public DateTime DtFechaSalida1
        {
            get { return DtFechaSalida; }
            set { DtFechaSalida = value; }
        }
        public string DtHora1
        {
            get { return DtHora; }
            set { DtHora = value; }
        }
        public int ICabaña
        {
            get { return iCabaña; }
            set { iCabaña = value; }
        }
        public int ICliente
        {
            get { return iCliente; }
            set { iCliente = value; }
        }
        public int IEmpleado
        {
            get { return iEmpleado; }
            set { iEmpleado = value; }
        }
        public DropDownList ObjCboReservas
        {
            get { return objCboReservas; }
            set { objCboReservas = value; }
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
                strError = "No definió la Descripción";
                return false;
            }
            if (iEmpleado ==0)
            {
                strError = "No selecciono ningún empleado";
                return false;
            }
            if (iCliente == 0)
            {
                strError = "No selecciono ningún cliente";
                return false;
            }
            if (iCabaña==0)
            {
                strError = "No selecciono ninguna cabaña";
                return false;
            }
            if (string.IsNullOrEmpty(DtFechaIngreso.ToString()))
            {
                strError = "No selecciono ninguna fecha de ingreso";
                return false;
            }
            if (string.IsNullOrEmpty(DtFechaSalida.ToString()))
            {
                strError = "No selecciono ninguna fecha de salida";
                return false;
            }
            if (string.IsNullOrEmpty(DtHora.ToString()))
            {
                strError = "No selecciono ninguna Hora";
                return false;
            }
            return true;
        }

         public bool Borrar()
         {
             if (iCliente == 0)
             {
                 strError = "No definió el documento del Cliente";
                 return false;
             }

             clsConexion oConexion = new clsConexion();

             strSQL = "DELETE FROM [DBHosteria_Tesoro].[dbo].[Reservas]"+
            "WHERE IdCliente = " + iCliente;

             //Se debe pasar la propiedad SQL al objeto conexion
         

             //Se invoca el método de consultar de la clase conexión
             
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

        public bool Actualizar()
        {
            if (Validar())
            {
                if (string.IsNullOrEmpty(strDocumento))
                {
                    strError = "No definió el documento del Cliente";
                    return false;
                }

                //Debe grabar en la base de datos
                //Se debe agregar una referencia a la librería: libComunes
                //y agregar el using en la libreria
                //Creamos la instancia de la clase conexion
                clsConexion oConexion = new clsConexion();

                //Debemos crear la instrucción SQL
                strSQL = "UPDATE [DBHosteria_Tesoro].[dbo].[Reservas]" +
                                   "SET [IdCliente] = " + iCliente+
                                    "  ,[IdCabaña] = "+ iCabaña +
                                     " ,[IdEmpleado] = " +iEmpleado+
                                      ",[Descripcion] = '" +strDescripción +
                                      "',[Nombre] = '" + strNombre +
                                      "',[FechaIngreso] = " +DtFechaIngreso+
                                     " ,[FechaSalida] = " +DtFechaSalida+
                                      ",[Hora] = " +DtHora+
                                 " WHERE IdReservas = " + iCodigo + ",>";


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
                strSQL = "INSERT INTO [DBHosteria_Tesoro].[dbo].[Reservas]([IdCliente],[IdCabaña],[IdEmpleado],[Descripcion],[FechaIngreso],[FechaSalida],[Hora] "+
               ") VALUES(" + iCliente+ "," + iCabaña+ "," +
                             iEmpleado + ",'" + strDescripción+ "','" + DtFechaIngreso.ToShortDateString()+ "','" +
                             DtFechaSalida.ToShortDateString()+ "','" + DtHora +"')";

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
                strError = "No definió el documento del Cliente";
                return false;
            }

            clsConexion oConexion = new clsConexion();

            strSQL = "SELECT      strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE, strDireccion_CLIE" +
  " " + " FROM         dbo.Cliente" +
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
        public bool LlenarGrid()
        {
            if (objGrdReservas == null)
            {
                strError = "No definió el grid de Reservas";
                return false;
            }
            
            strSQL = "SELECT     Promocion.Nombre AS Promocion, Implementos.Nombre AS Implementos, Servicio.Nombre AS Servicio, Tarifa.Nombre AS Tarifa, Tarifa.Valor AS ValorTarifa, "+
                      " Cliente.strDocumento_CLIE AS Cliente, Reservas.FechaIngreso AS Ingreso, Reservas.FechaSalida AS Salida, Cabaña.Nombre AS Cabaña "+
" FROM         Cabaña LEFT OUTER JOIN "+
                     " Tarifa ON Cabaña.IdTarifa = Tarifa.IdTarifa LEFT OUTER JOIN "+
                     " Promocion ON Cabaña.IdCabaña = Promocion.IdCabaña LEFT OUTER JOIN "+
                     " Servicio ON Cabaña.IdServicio = Servicio.IdServicio LEFT OUTER JOIN "+ 
                     " Implementos ON Cabaña.IdImplementos = Implementos.IdImplementos RIGHT OUTER JOIN "+
                     " Reservas ON Cabaña.IdCabaña = Reservas.IdCabaña LEFT OUTER JOIN "+
                     " Empleado ON Reservas.IdEmpleado = Empleado.strDocumento_EMPL LEFT OUTER JOIN "+
                    "  Cliente ON Reservas.IdCliente = Cliente.strDocumento_CLIE "+
                    "WHERE				dbo.Reservas.IdCliente = " +strDocumento;

            //Se crea el objeto de grid y se le pasan las propiedades gridview, sql y nombre tabla
            clsGrid oGrid = new clsGrid();

            oGrid.gridGenerico = objGrdReservas;
            oGrid.SQL = strSQL;
            oGrid.NombreTabla = "Reserva";

            if (oGrid.LlenarGridWeb())
            {
                objGrdReservas = oGrid.gridGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                strError = oGrid.Error;
                oGrid = null;
                return false;
            }
        }


        #endregion
    }
}
