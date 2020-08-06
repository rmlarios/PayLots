using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Web.UI;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System.Web.Security;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Diagnostics;
using System.Linq;



namespace cls_GENERAL
{
    public enum TipoMensaje { MsgBox, Etiqueta };
    public class Cls_General
    {
        //INICIALIZANDO LA CLASE(CONSTRUCTOR)
        public Cls_General()
        {
            //NombreInstancia = "10.38.91.10";
            //NombreBD = "SICINFO";
            //NombreUsuarioBD = "SICINFO_USER";
            //ContraseñaUsuario = "Sicinfo@123";

            //NombreInstancia = "ERICK-PC\\SQLSERVER2014";
            //NombreBD = "SICINFO_PRUEBA";
            //NombreUsuario = "sa";
            //ContraseñaUsuario = "Desarrollo2014";

            //NombreInstancia = "MEM-INFO-10\\MSSQLSERVER2016";
            //NombreBD = "SICINFO";
            //NombreUsuarioBD = "SICINFO_USER";
            //ContraseñaUsuario = "Sicinfo@123";

            NombreInstancia = "SRV-DB";
            NombreBD = "PayLots";
            NombreUsuarioBD = "SICINFO_USER";
            ContraseñaUsuario = "Sicinfo@123";

            //_Conexion = new SqlConnection("Data Source=" + _NombreInstancia.ToString() + ";Initial Catalog=" + _NombreBD.ToString() + ";Persist Security Info=True;User ID=" + _NombreUsuarioBD.ToString() + ";Password=" + _ContraseñaUsuario.ToString());
            _Conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["PayLotsConnectionString"].ConnectionString);
        }

        #region "VARIABLES, PROPIEDADES Y ENUMERADORES"
        //public string Hostname = "Aplicacionesmem";
        public string Nombre_Sistema="PayLots";
        public string NS = "PayLots";
        public string NDB = "PayLots";
        public NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;
        private SqlConnection _Conexion;
        public SqlConnection Conexion
        {
            get {return _Conexion; }
            set {_Conexion = value; }
        }
        private string _sFile;
        public string sFile
        {
            get {return _sFile;}
            set {_sFile = value;}
        }
        public string _NombreInstancia;
        public string NombreInstancia
        {
            get {return _NombreInstancia;}
            set {_NombreInstancia = value;}
        }
        public string _NombreBD;
        public string NombreBD
        {
            get {return _NombreBD;}
            set {_NombreBD = value;}
        }
        public string _NombreUsuario;
        private string NombreUsuario
        {
            get {return _NombreUsuario;}
            set {_NombreUsuario = value;}
        }
        public string _NombreUsuarioBD;
        public string NombreUsuarioBD
        {
            get {return _NombreUsuarioBD; }
            set {_NombreUsuarioBD = value; }
        }
        public string _ContraseñaUsuario;
        public string ContraseñaUsuario
        {
            get { return _ContraseñaUsuario; }
            set { _ContraseñaUsuario = value; }
        }
        private SqlCommand _SqlComando;
        public SqlCommand SqlComando
        {
            get { return _SqlComando; }
            set { _SqlComando = value; }
        }

        private SqlDataAdapter _SqlAdapter;
        public SqlDataAdapter SqlAdapter
        {
            get { return _SqlAdapter; }
            set { _SqlAdapter = value; }
        }
        private SqlDataReader _SqlReader;
        public SqlDataReader SqlReader
        {
            get { return _SqlReader; }
            set { _SqlReader = value; }
        }
        private DataSet _MyDataSet;
        public DataSet MyDataSet
        {
            get { return _MyDataSet; }
            set { _MyDataSet = value; }
        }
        private DataSet _DataSetGlobal;
        public DataSet DataSetGlobal
        {
            get { return _DataSetGlobal; }
            set { _DataSetGlobal = value; }
        }
        private string _CadenaSql;
        public string CadenaSql
        {
            get { return _CadenaSql; }
            set { _CadenaSql = value; }
        }
        
        public string DocsGenerados;// = HttpContext.Current.Server.MapPath("~\\Documentos\\");
        public string DocsGenerados_Server_BD;// = "\\" + "\\SRV-DB\\DocsGenerados\\";

        public bool Repeat;

        private string _Ubicacion;
        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }
        private string _Sesion_Id;
        public string Sesion_Id
        {
            get { return _Sesion_Id; }
            set { _Sesion_Id = value; }
        }

        private string _Servidor_Correo_Saliente;
        public string Servidor_Correo_Saliente
        {
            get { return _Servidor_Correo_Saliente; }
            set { _Servidor_Correo_Saliente = value; }
        }


        //ENUMERADOR GENERAL DEL SISTEMA
        public enum EnumSICINFO
        {
            Accesorio,
            AccesorioAsignacion,
            AccesorioAsignacionDetalle,
            Año,
            Articulo,
            ArticuloAsociado,
            Asignacion,
            AsignacionArticulo,
            AsignacionComponenteInterno,
            AsignacionAccesorio,
            AsignacionDetalleArticulo,
            AsignacionDetalleComponenteInterno,
            AsignacionDetalleAccesorio,
            AsignadoA,
            Area,
            BajaBien,
            BajaBienDetalle,
            Bodega,
            ComponentesInterno,
            ComponenteInterno,
            ComponenteInternoArticulo,
            CambioParte,
            CambioParteA,
            CambioParteRetiro,
            CambioParteRepuesto,
            CambioParteDetalle,
            Cargo,
            Entrada,
            EntradaDetalleArticulo,
            EntradaDetalleComponenteInterno,
            EntradaArticulo,
            EntradaComponenteInterno,
            EntradaAccesorio,
            EquipoAsociado,
            EquipoBajaBien,
            EquipoComputo,
            EquiposSeleccionados,
            Estado,
            Marca,
            Modelo,
            PersonalExterno,
            Proveedor,
            Prestamo,
            PrestadoA,
            PrestamoArticulo,
            PrestamoDetalleArticulo,
            PrestamoDetalleComponenteInterno,
            RecibidoPor,
            Retiro,
            RetiradoA,
            RetiradoA_Accesorio,
            RetiroArticulo,
            RetiroComponenteInterno,
            RetiroAccesorio,
            RetiroDetalleArticulo,
            RetiroDetalleComponenteInterno,
            RetiroDetalleAccesorio,
            Software,
            SoftwareInstalado,
            TipoAccesorio,
            TipoArticulo,
            TipoManufactura,
            TipoClasificacion,
            TipoEspecificacion,
            TipoComponenteInterno,
            TipoRetiro,
            Factura,
            Consumible,
            AccesorioImpresora,
            PuedePrestarse

        }
        #endregion

        public void AbrirConexion()
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
        }
        ////Funcion que cierra la conexión con la base de datos
        public void CerrarConexion()
        {

            if (_Conexion.State == ConnectionState.Open)
            {
                _Conexion.Close();
            }
        }
        //'*****************************************************************************************************
        //'FUNCION PARA EXTRAER EL VALOR DE UN REGISTRO EN UN CAMPO DE LA BD, PUEDE SER STRING, ENTERO, BOOLEAN
        //'HAY QUE CONVERTIR LO QUE DEVUELVE LA FUNCION EN LA CAPA DE NEGOCIO
        //'*****************************************************************************************************
        public string ObtenerValorCampo(string StrSQL)
        {
            string Retorno = string.Empty;
            _SqlComando = new SqlCommand();
            _SqlReader = null;
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = StrSQL;
            _SqlComando.CommandType = CommandType.Text;
            _SqlReader = _SqlComando.ExecuteReader(CommandBehavior.Default);
            while (_SqlReader.Read())
            {
                Retorno = _SqlReader.GetValue(0).ToString();
            }
            _SqlReader.Close();
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //'FUNCION PARA VERIFICAR SI LA CONSULTA ENVIADA DEVUELVE AL MENOS UN REGISTRO
        //'*****************************************************************************************************
        public Boolean ExistenDatos(string Cadena)
        {
            Boolean Retorno = false;
            _MyDataSet = new DataSet();
            AbrirConexion();
            _SqlAdapter = new SqlDataAdapter(Cadena, _Conexion.ConnectionString);
            _SqlAdapter.Fill(_MyDataSet, "Data");
            if (_MyDataSet.Tables["Data"].Rows.Count != 0)
            {
                Retorno = true;
            }
            else
            {
                Retorno = false;
            }
            _MyDataSet = null;
            _SqlAdapter = null;
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL(EXEC, INSERT, UPDATE, DELETE, ETC)
        //'*****************************************************************************************************
        public void ExecuteSql(string Sqlstr)
        {
            _SqlComando = new SqlCommand();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = Sqlstr;
            _SqlComando.CommandType = CommandType.Text;
            _SqlComando.ExecuteReader();
            _SqlComando.Connection.Close();
            CerrarConexion();
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL ESCALAR PARA OBTENER UN REGISTRO DE TIPO OBJECT(STRING, ENTERO, DECIMAL, ETC)
        //HAY QUE CONVERTIR LO QUE DEVUELVE LA FUNCION EN LA CAPA DE NEGOCIO   
        //'*****************************************************************************************************
        public Object ExecuteSQLEscalar(string Sqlstr)
        {
            object Retorno = new object();
            _SqlComando = new SqlCommand();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = Sqlstr;
            _SqlComando.CommandType = CommandType.Text;
            Retorno = _SqlComando.ExecuteScalar();
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        // DEVUELVE UN DATASET CON REGISTROS DE UNA CONSULTA PARA QUE POSTERIORMENTE SE PUEDA RECORRER
        //'*****************************************************************************************************
        public DataSet LlenarDataSet(string Sqlstr, string NameTable)
        {
            DataSet Retorno = new DataSet();
            AbrirConexion();
            _SqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion.ConnectionString);
            _MyDataSet = new DataSet();
            if (NameTable.Length != 0)
            {
                _SqlAdapter.Fill(_MyDataSet, NameTable);
            }
            else
            {
                _SqlAdapter.Fill(_MyDataSet);
            }
            Retorno = _MyDataSet;
            _MyDataSet = null;
            _SqlAdapter = null;
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //FUNCION QUE DEVUELVE UN DATATABLE DE UNA LISTA (DE DISTINTOS TIPOS)
        //'*****************************************************************************************************
        public DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public DataTable LlenarTbl(string SqlString)
        {
            DataTable Retorno = new DataTable();
            _SqlComando = new SqlCommand();
            _SqlAdapter = new SqlDataAdapter();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandType = CommandType.Text;
            _SqlComando.CommandText = SqlString;

            _SqlAdapter.SelectCommand = _SqlComando;
            _SqlAdapter.Fill(Retorno);
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //FUNCION PARA EJECUTAR UN PROCEDIMIENTO UTILIZANDO LA VARIABLE _SQLCOMMAND, ESTA VARIABLE DEBE ESTAR CON LOS PARAMETROS INGRESADOS ANTES DE EJECUTAR DICHA FUNCION
        public object EjecutarProcedimiento()
        {
            Object Retorno = null;
            Retorno = _SqlComando.ExecuteScalar();
            _SqlComando.Parameters.Clear();
            _SqlComando.Connection.Close();
            return Retorno;
        }
        //FUNCION PARA INICIAR LA EJECUCION DE UN PROCEDIMIENTO ALMACENADO CON LA VARIABLE _SQLCOMMAND
        public void IniciarProcedimiento(string NombreProcedimiento)
        {
            _SqlComando = null;
            _SqlComando = new SqlCommand();
            _SqlComando.Connection = Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Open)
                _SqlComando.Connection.Close();
            _SqlComando.Connection.Open();
            _SqlComando.CommandType = CommandType.StoredProcedure;
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = NombreProcedimiento;
        }
        //FUNCION PARA AGREGAR UN PARAMETRO A LA VARIABLE _SQLCOMMAND QUE ES CON LA CUAL SE EJECUTA LA FUNCION EJECUTAR_PROCEDIMIENTO
        public void AgregarParametroProcedimiento(String NombreParametro, System.Data.SqlDbType TipoParametro, Object ValorParametro)
        {
            _SqlComando.Parameters.Add(NombreParametro, TipoParametro).Value = ValorParametro;
        }

        //FUNCION PARA GUARDAR UN ARCHIVO(TODO TIPO) QUE DEVUELVE UN OBJETO TIPO byte[]
        //public byte[] GuardarArchivoEnBD(string RutaArchivo, string SQLQuery)
        //{
        //    byte[] Retorno = null;
        //    Stream StreamObject = null;
        //    BinaryReader BinaryReaderObject = null;
        //    _SqlComando = new SqlCommand();
        //    StreamObject = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read);
        //    BinaryReaderObject = new BinaryReader(StreamObject);
        //    Retorno = BinaryReaderObject.ReadBytes((int)StreamObject.Length);
        //    AbrirConexion();
        //    _SqlComando = new SqlCommand(SQLQuery, _Conexion);
        //    _SqlComando.Parameters.Add("@Archivo", SqlDbType.VarBinary, Retorno.Length).Value = Retorno;
        //    _SqlComando.ExecuteNonQuery();
        //    return Retorno;
        //}

        //public byte[] LeerArchivoEnBD(Int32 ID, string SQLQuery)
        //{
        //    byte[] Retorno = null;
        //    FileStream Fs = null;
        //    Stream StreamObject = null;
        //    BinaryReader BinaryReaderObject = null;
        //    _SqlComando = new SqlCommand();
        //    string Ruta = string.Empty;
        //    AbrirConexion();
        //    _SqlComando = new SqlCommand(SQLQuery, _Conexion);
        //    _SqlComando.Parameters.AddWithValue("@ID", ID);
        //    _SqlReader = _SqlComando.ExecuteReader();
        //    if (_SqlReader != null)
        //    {
        //        _SqlReader.Read();
        //        Retorno = new byte[(_SqlReader.GetBytes(0, 0, null, 0, int.MaxValue))];
        //        _SqlReader.GetBytes(0, 0, Retorno, 0, Retorno.Length);
        //        Ruta = "D:\\";
        //        //Ruta = System.IO.Directory.GetCurrentDirectory();
        //        Fs = new FileStream(Ruta, FileMode.Create, FileAccess.Write);
        //        Fs.Write(Retorno, 0, Retorno.Length);

        //        StreamObject = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
        //        BinaryReaderObject = new BinaryReader(StreamObject);
        //        Retorno = BinaryReaderObject.ReadBytes((int)StreamObject.Length);
        //    }
        //    return Retorno;

        //    //StreamObject = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read);
        //    //BinaryReaderObject = new BinaryReader(StreamObject);
        //    //Archivo = BinaryReaderObject.ReadBytes((int)StreamObject.Length);

        //    //_SqlComando.Parameters.Add("@Archivo", SqlDbType.VarBinary, Archivo.Length).Value = Archivo;
        //    //_SqlComando.ExecuteNonQuery();
        //    //return Archivo;

        //    //using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
        //    //using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection))
        //    //{
        //    //    sqlQuery.Parameters.AddWithValue("@varID", varID);
        //    //    using (var sqlQueryResult = sqlQuery.ExecuteReader())
        //    //        if (sqlQueryResult != null)
        //    //        {
        //    //            sqlQueryResult.Read();
        //    //            var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
        //    //            sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
        //    //            using (var fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write))
        //    //                fs.Write(blob, 0, blob.Length);
        //    //        }
        //    //}

        //}
        //ESTA FUNCION CREA UN ID UNICO PARA ENVIARLO EN LOS PROCEDIMIENTOS ALMACENADOAS EN DONDE SE REGISTRAN LOS ERRORES OCURRIDOS EN CASOS DE ROLLBACK,
        //''DICHOS ERRORES SE GUARDAN EN LA TABLA ERRORSQL CON UN IDENDIFICADOR DE USUARIO, EL CUAL ES CREADO ANTES DE EJECUTAR EL PROCEDIMIENTO Y CONSULTADO EN LA TABLA DESPUES DE EJECUTAR EL PROCEDIMIENTO.
        public string CrearIdentificadorUsuario(string NombreUsuarioConectado)
        {
            string Retorno = "";
            Retorno = NombreUsuarioConectado + System.DateTime.Now.Date.ToShortDateString() + System.DateTime.Now.ToString("HH:mm:ss");
            return Retorno;
        }
        public string Obtener_MensajeSQL(string IdentityUser)
        {
            DataSet ErroresSQL = new DataSet();
            string MensajeErrorSQL = "";
            ErroresSQL = LlenarDataSet("SELECT DISTINCT(ISNULL(ErrorSQL,'')) AS Error FROM dbo.ErrorSQL WHERE IdentityUser='" + IdentityUser + "' AND ISNULL(ErrorSQL,'') <> ''", "Tbl");
            if (ErroresSQL.Tables["Tbl"].Rows.Count > 0)
            {
                MensajeErrorSQL = ErroresSQL.Tables["Tbl"].Rows[0][0].ToString();
                //ExecuteSql("DELETE FROM dbo.ErrorSQL WHERE IdentityUser='" + IdentityUser + "'");
            }
            return MensajeErrorSQL;
        }
        //FUNCION QUE LLENA UN GRIDCONTROL CON GRIDMASTER Y GRIDDETALLE
        public DataTable CargarMasterDetalle(string StrSQLMaster, string StrSQLDetalle, string Str_IDRelacionado)
        {
            DataTable Retorno = null;
            DataSet DSMaster = null;
            DataTable TblMaster = null;
            DataTable TblDetalle = null;
            DSMaster = new DataSet();
            TblMaster = new DataTable();
            TblMaster.TableName = "Marster";
            TblDetalle = new DataTable();
            TblDetalle.TableName = "Detalle";
            TblMaster = LlenarTbl(StrSQLMaster);
            TblDetalle = LlenarTbl(StrSQLDetalle);
            DSMaster.Tables.Add(TblMaster);
            DSMaster.Tables.Add(TblDetalle);
            DSMaster.Relations.Add("Detalle", DSMaster.Tables[0].Columns[Str_IDRelacionado], DSMaster.Tables[1].Columns[Str_IDRelacionado], false);
            Retorno = TblMaster;
            return Retorno;
        }
        //VALIDANDO UNA FECHA CON DATO NO NULO
        public Boolean IsDate(String fecha)
        {
            try
            {
                if ((DateTime.Parse(fecha)).Year > 1900)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL PARA EL CAMBIO DE CONTRASEÑA DE USUARIO
        //'*****************************************************************************************************
        public void Cambiar_Contraseña_SQL(string Usuario, string Password_Anterior, string Password_Nuevo)
        {
            ExecuteSql("sp_password @old =" + Password_Anterior + ", @new =" + Password_Nuevo + " , @loginame=" + Usuario + "");
        }
        //'*****************************************************************************************************
        //FUNCION PARA VALIDAR EL FORMATO CORRECTO DE UNA CONTRASEÑA DE USUARIO
        //'*****************************************************************************************************
        public bool ValidarPassword(string Pwd)
        {
            int i = 0; bool HayNumero = false; bool HayMayuscula = false; bool HayMinuscula = false; bool HayCaracterEspecial = false;

            //Validar Longitud
            if (Pwd.Length < 8)
            {
                return false;
            }
            //BUSCAR NUMERO
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsNumber(Pwd, i) == true)
                {
                    HayNumero = true;
                    break;
                }
            }

            //BUSCAR MAYUSCULA
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsUpper(Pwd, i) == true)
                {
                    HayMayuscula = true;
                    break;
                }
            }

            //BUSCAR MINUSCULA
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsLower(Pwd, i) == true)
                {
                    HayMinuscula = true;
                    break;
                }
            }

            string caracter;
            Encoding Ascii = Encoding.ASCII;
            //BUSCAR CARACTER ESPECIAL
            for (i = 0; i < Pwd.Length; i++)
            {
                caracter = Pwd.Substring(i, 1);
                byte[] Valor = Ascii.GetBytes(caracter);
                if ((Valor[0] >= 60 && Valor[0] <= 64) || (Valor[0] >= 30 && Valor[0] <= 47)) //ENTRE 60 Y 64 Ó 30 Y 47
                {
                    HayCaracterEspecial = true;
                    break;
                }
            }

            //SI HAY VALOR
            if (HayNumero == true && HayCaracterEspecial == true && HayMayuscula == true && HayMinuscula == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public void FilldataSource(SqlDataSource SqlDS, string SqlstrDS)
        {
            AbrirConexion();
            SqlDS.ConnectionString = Conexion.ConnectionString;
            SqlDS.SelectCommandType = SqlDataSourceCommandType.Text;
            
            SqlDS.SelectCommand = SqlstrDS;
            CerrarConexion();
        }
        public void FilldataSource_DataBind_Dev(Control Ctrl, string Sqlstr, object LinQ, Boolean ActivePropertyGrid)
        {

            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            if (Sqlstr != "")
            {
                SqlDataAdapter MysqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion);
                DataSet Mydataset = new DataSet();
                MysqlAdapter.Fill(Mydataset);
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
            }
            else
            {
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
            }
            if (ActivePropertyGrid == false)
            {
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataBind();
                }
            }
            _Conexion.Close();
        }
        public void MakeRecordSet(DataSet MyDataSet, string Sqlstr, string NameTable)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            SqlDataAdapter MySqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion.ConnectionString);
            if (NameTable.Length != 0)
            {
                MySqlAdapter.Fill(MyDataSet, NameTable);
            }
            else
            {
                MySqlAdapter.Fill(MyDataSet);
            }
            MyDataSet = null;
        }
        public HttpCookie CrearCokie(string Cokie, string Valor)
        {
            HttpCookie CrearCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            return CrearCokie;
        }
        //Procedimiento que permite abrir una pantalla modal
        public void Show_Windows(Page Pagina, Type Tipe, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, "PopupMensajes", "<script>" + Funcion + ";</script>", false);
        }
        private Type _tipo;
        public Type Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public HttpCookie EliminarCokie(string Cokie, string Valor)
        {
            HttpCookie EliminarCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            EliminarCokie.Expires = DateTime.Now.AddDays(-1d);
            return EliminarCokie;

        }

        public void Limpiar_Cookies(HttpResponse Resp)
        {
            Resp.Cookies.Add(EliminarCokie("NombreGrupo", ""));
            Resp.Cookies.Add(EliminarCokie("NombreUsuario", ""));
            Resp.Cookies.Add(EliminarCokie("MyLogSI", ""));
        }
        public void BorrarArchivo(string Archivo)
        {
            string FileToDelete;

            FileToDelete = DocsGenerados + Archivo;
            if (File.Exists(FileToDelete) == true)
            {
                File.Delete(FileToDelete);
            }
        }
        public string GenerarNombreFichero()
        {
            int ultimoTick = 0;
            while (ultimoTick == Environment.TickCount)
            {
                System.Threading.Thread.Sleep(1);
            }
            ultimoTick = Environment.TickCount;
            return DateTime.Now.ToString("yyyyMMddhhmmss") + "." +
            ultimoTick.ToString();
        }
        
        public void CargarArchivoLeer(string SqlCadenaArchivo, string NameArchivo)
        {
            SqlCommand mysql1 = new SqlCommand();
            mysql1.Connection = _Conexion;

            if (mysql1.Connection.State == ConnectionState.Closed)
            {
                mysql1.Connection.Open();
            }
            mysql1.CommandText = SqlCadenaArchivo;
            mysql1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(mysql1);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            if (ds.Tables[0].Rows[0].ItemArray[0].GetType().Name == "DBNull") { return; }
            byte[] bits = (byte[])(ds.Tables[0].Rows[0].ItemArray[0]);
            mysql1.Connection.Close();

            //sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo +".pdf";
            _sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo ;
            //sFile = NameArchivo;
            FileStream fs = new FileStream(DocsGenerados + _sFile, FileMode.Create);
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            fs.Close();
        }
        public void RegisterUpdatePanel(UpdatePanel UpdatePanel, Page Page)
        {
            var sType = typeof(ScriptManager);
            var mInfo = sType.GetMethod("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mInfo != null)
                mInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { UpdatePanel });
        }
        //public Boolean Enviar_Correo(string Remitente, string Destinatario, string Asunto, string Cuerpo_Mensaje, string copias)
        //{
        //    try
        //    {
        //        if (Destinatario != "")
        //        {
        //            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        //            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //            correo.From = new System.Net.Mail.MailAddress(Remitente);
        //            correo.Subject = Asunto.Trim();
        //            correo.To.Add(Destinatario);
        //            if (copias != "")
        //            {
        //                correo.CC.Add(copias);
        //            }
        //            correo.Body = Cuerpo_Mensaje;
        //            correo.Priority = System.Net.Mail.MailPriority.Normal;
        //            smtp.Host = "mail.mem.gob.ni";
        //            smtp.Send(correo);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (System.Net.Mail.SmtpException Ex)
        //    {
        //        return true;
        //    }

        //}

        //CONTROLAR LOS ERRORES DEL SISTEMA
        public void Controlador_Error_old(Exception Ex, HttpResponse Resp)
        {
            if (Ex.Message != "Subproceso anulado.")
            {
                if (Repeat == false)//LA VARIABLE SE USA PARA CONTROLAR QUE EL EVENTO NO SE EJECUTE MAS DE UNA VEZ
                {
                    Repeat = true;
                    if (Ex is SqlException)
                    {
                        SqlException SqlEx = (SqlException)Ex;
                        //AQUI SE PONDRAN LOS NUMEROS DE ERRORES PERSONALIZADOS
                        if (SqlEx.Number == 53)//ERROR DE CONEXION
                        {
                            Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", "Error de conexion al servidor. Contacte al administrador del sistema"));
                        }
                        else
                        {
                            Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                        }
                        Resp.Redirect("~/Error_Page.aspx", true);
                        Limpiar_Cookies(Resp);
                    }
                    //if (HttpContext.Current.Request.Cookies.Get("lblMensajeErrorPage") != null && HttpContext.Current.Request.Cookies.Get("lblMensajeErrorPage").Value != "")
                    //{
                    //    Resp.Redirect("~/Error_Page.aspx", true);
                    //    Limpiar_Cookies(Resp);
                    //}
                    else
                    {
                        Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                        Resp.Redirect("~/Error_Page.aspx", true);
                        Limpiar_Cookies(Resp);
                    }
                }
            }
        }

        //Nuevo Controlador Error
        public void Controlador_Error_old2(Exception Ex, HttpResponse Resp, Enum TipoMessage = null)
        {
            if (Ex.Message == "Subproceso anulado.") { return; }
            if (Repeat == false)
            {
                Page PG = HttpContext.Current.Handler as Page;
                string NombrePagina = HttpContext.Current.Session["NombrePagina"]!=null ? HttpContext.Current.Session["NombrePagina"].ToString() : PG.Request.Url.Segments[PG.Request.Url.Segments.Length - 1];
                string usuario = "";
                Repeat = true;
                string CodError = "";

                if (TipoMessage == null)
                {
                    TipoMessage = TipoMensaje.Etiqueta;
                }

                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("NombreUsuario") == true)
                {
                    usuario = HttpContext.Current.Request.Cookies.Get("NombreUsuario").Value;//Accedo a la cookie del NombreUsuario
                }
                else
                {
                    usuario = HttpContext.Current.Request.UserHostName; //Ip del Usuario que ejecuta

                }
                string error = Ex.Message.Replace("'", " ");//Reemplazo comillas simples para evitar error al ejecutar la Insercion
                StackTrace stackTrace = new StackTrace(Ex, true);
                error = error + Environment.NewLine + "Origen:" + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetMethod().Name + Environment.NewLine + "Linea: " + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetFileLineNumber();

                CodError = DateTime.Now.ToString("yyyy-MMddhhmmss");//Codigo unico del error para referencia del usuario

                ExecuteSql("INSERT INTO COMUN..ErroresSistema (Sistema,Descripcion, Fecha, Usuario, Pantalla,CodError) VALUES('" + Nombre_Sistema + "','" + error + "',GETDATE(),'" + usuario + "','" + NombrePagina + "','" + CodError + "')");


                //WebUserControlMensajes WUCMensajes = (WebUserControlMensajes)PG.LoadControl(@"~/Procesos/WebUserControlMensajes.ascx");

                //Verifico si la pagina esta asociado a un Site Master
                var master = PG.Master;
                //Validar que tipo de mensaje se mostrara
                if (TipoMessage.ToString() == "MsgBox")
                {
                    //WebUserControlMensajes WUCMensajes = (WebUserControlMensajes)PG.LoadControl(@"~/Procesos/WebUserControlMensajes.ascx");
                    if (master != null)
                    {
                        System.Web.UI.HtmlControls.HtmlForm form = (System.Web.UI.HtmlControls.HtmlForm)PG.Master.FindControl("form1");
                      //  form.Controls.Add(WUCMensajes);
                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlForm form = (System.Web.UI.HtmlControls.HtmlForm)PG.FindControl("form1");
                        //form.Controls.Add(WUCMensajes);
                    }
                    //WUCMensajes.MostrarPopup(Ex.Message, 0, false);
                }
                else
                {
                    if (master != null)
                    {
                        ASPxLabel lblMaster = (ASPxLabel)PG.Master.FindControl("lblMaster");
                        lblMaster.Text = "Se ha producido un error, reintente o contacte al Administrador del Sistema. Ref.: " + CodError; ;
                    }
                    else
                    {
                        ASPxLabel lblMaster = (ASPxLabel)PG.Form.FindControl("lblMaster");
                        lblMaster.Text = Ex.Message;
                    }
                }





            }
        }

        public void Controlador_Error(Exception Ex, HttpResponse Resp, Enum TipoMessage = null)
        {
            if (Ex.Message == "Subproceso anulado.") { return; }
            if (Repeat == false)
            {
                Page PG = HttpContext.Current.Handler as Page;
                string NombrePagina = HttpContext.Current.Session["NombrePagina"] != null ? HttpContext.Current.Session["NombrePagina"].ToString() : PG.Page.AppRelativeVirtualPath.Substring(PG.Page.AppRelativeVirtualPath.LastIndexOf("/") + 1);
                ;
                string usuario = "";
                Repeat = true;
                string CodError = "";

                

                if (HttpContext.Current.User != null)
                {
                    usuario = HttpContext.Current.User.Identity.Name;//Accedo al NombreUsuario
                }
                else
                {
                    usuario = HttpContext.Current.Request.UserHostName; //Ip del Usuario que ejecuta

                }
                string error = Ex.Message.Replace("'", " ");//Reemplazo comillas simples para evitar error al ejecutar la Insercion
                if (Ex.InnerException != null)
                {
                    error = error + Ex.InnerException.Message.Replace("'", " ");
                }
                StackTrace stackTrace = new StackTrace(Ex, true);
                error = error + Environment.NewLine + "Origen:" + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetMethod().Name + Environment.NewLine + "Linea: " + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetFileLineNumber();

                CodError = DateTime.Now.ToString("yyyy-MMddhhmmss");//Codigo unico del error para referencia del usuario


                ExecuteSql("INSERT INTO ErroresSistema (Error, Fecha, Usuario, Pantalla,CodError) VALUES('" + error + "',GETDATE(),'" + usuario + "','" + NombrePagina + "','" + CodError + "')");

                if (Ex.GetType().FullName != "System.Web.HttpUnhandledException")
                    Ejecutar_Funcion_JavaScript(PG, PG.GetType(), "err_msg", "alert('Se ha producido un error inesperado.');");

            }
        }
        public string Acceso_Sistema(HttpResponse Resp, HttpRequest Req, string Usuario, string Perfil, string Pantalla)
        {
            try
            {
                //PREGUNTAR POR LA CO0KIE DE SESION
                HttpCookie authCookie = Req.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return "TimeOut";
                }
                else if (Req.Cookies.Get("NombreGrupo").Value == null)
                {
                    return "Ninguno";
                }
                else
                {
                    //DataSet DataSetGlobal_1 = new DataSet();
                    //MakeRecordSet(DataSetGlobal_1, "SELECT Pantalla FROM COMUN..VW_SISTEMA_PERFIL_PANTALLA WHERE (Perfil = '" + Perfil + "') AND (Usuario = '" + Usuario + "') AND (Pantalla = '" + Pantalla + "')", "T");
                    //if (DataSetGlobal_1.Tables["T"].Rows.Count != 0)
                    //{
                        return "Si";
                    //}
                    //else
                    //{
                    //    return "Ninguno";
                    //}
                }
            }
            catch (Exception Ex)
            {
                Limpiar_Cookies(Resp);
                Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                Resp.Redirect("~/Error_Page.aspx", true);
                return "Ninguno";
            }
        }

        public void ObtenerParametrosComun()
        {
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT * FROM VW_PARAMETROS_COMUN", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                _Ubicacion = DataSetGlobal.Tables["T"].Rows[0]["Ubicacion"].ToString();
                _Servidor_Correo_Saliente = DataSetGlobal.Tables["T"].Rows[0]["Servidor_Correo_Saliente"].ToString();
            }
            DataSetGlobal.Clear();
        }

        public string ObtenerMensaje(int Mensaje_Id)
        {
            _DataSetGlobal = new DataSet();
            MakeRecordSet(_DataSetGlobal, "SELECT Descripcion FROM COMUN..Catalogo_Mensajes WHERE (Mensaje_Id = " + Mensaje_Id + ")", "T");
            if (_DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                return _DataSetGlobal.Tables["T"].Rows[0]["Descripcion"].ToString();
            }
            else
            {
                return "No hay mensaje que mostrar. Consulte al administrador del sistema";
            }
        }
        public void Logueos_Usuarios(string Usuario,string Rol)
        {
            string clientMachineName = HttpContext.Current.Request.UserHostAddress;
            string Sesion_Id = (DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString()).ToString();
            ExecuteSql("INSERT INTO Control_Acceso_Usuarios (Sesion_Id, Usuario, Perfil, FAR, PC) VALUES (" + Sesion_Id + ", '" + Usuario.Trim() + "','" + Rol + "' , GETDATE(), '" + clientMachineName.Trim() + "')");
        }

        public string Grupo(string Usuario)
        {

            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }

            string NGrupo = "";
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT Perfil FROM COMUN..vw_aspnet_UsersInRoles WHERE (Usuario = '" + Usuario + "') AND (Aplicacion = '" + appSettings.Get("NAPLICATION") + "')", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                NGrupo = DataSetGlobal.Tables["T"].Rows[0]["Perfil"].ToString();
            }

            _Conexion.Close();
            return NGrupo;
        }

        //EJECUTAR FUNCION JAVASCRIPT
        public void Ejecutar_Funcion_JavaScript(Page Pagina, Type Tipe, string KeyInstanceName, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, KeyInstanceName, "<script>" + Funcion + ";</script>", false);
        }


       public Boolean ValidarRespuesta(string Usuario, string Respuesta)
        {
            Boolean Retorno = false;
            Respuesta = Respuesta.ToLower();
            DataSet Historico = new DataSet();
            MakeRecordSet(Historico, "SELECT [PasswordAnswer],[PasswordSalt] FROM aspnet_Membership WHERE [UserId]='" + Usuario + "'", "");
            if (Historico.Tables[0].Rows.Count != 0)
            {
                //Aplico el PasswordSalt de las contraseñas almacenadas en el historico a la Nueva Contraseña
                string NuevaRespuesta = GenerateHash(Respuesta, Historico.Tables[0].Rows[0]["PassWordSalt"].ToString());
                //Comparo la Nueva Contraseña una vez aplicado el Hash con las Contraseñas Almacenadas
                if (NuevaRespuesta == Historico.Tables[0].Rows[0]["PasswordAnswer"].ToString())
                    return true;


            }

            return Retorno;
        }

        //APLICAR HASH A UNA CADENA
        private static string GenerateHash(string pwd, string saltAsBase64)
        {
            byte[] p1 = Convert.FromBase64String(saltAsBase64);
            return GenerateHash(pwd, p1);
        }

        private static string GenerateHash(string pwd, byte[] saltAsByteArray)
        {
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            byte[] p1 = saltAsByteArray;
            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(pwd);

            byte[] data = new byte[p1.Length + p2.Length];

            p1.CopyTo(data, 0);
            p2.CopyTo(data, p1.Length);

            byte[] result = sha.ComputeHash(data);

            string res = Convert.ToBase64String(result);
            return res;
        }



    }
}
