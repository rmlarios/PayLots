using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/*Usados en el sistema*/
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;//WindowsIdentity
using System.Data.OleDb;
using System.Text;
//using System.Data.Objects;
//using System.Data.Objects.DataClasses;
using System.Reflection;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;


namespace SILA
{
    public enum TipoMensaje { MsgBox, Etiqueta }
    //Clase principal donde se declaran las variables, funciones y procedimientos globales del sistema
    public class General
        
    {
        public bool Repeat;
        private SqlConnection _Conexion;
        public SqlConnection Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _Correo_General_Parametro;
        public string Correo_General_Parametro
        {
            get { return _Correo_General_Parametro; }
            set { _Correo_General_Parametro = value; }
        }

        private string _Siglas_Area_Parametro;
        public string Siglas_Area_Parametro
        {
            get { return _Siglas_Area_Parametro; }
            set { _Siglas_Area_Parametro = value; }
        }

        private int _i;
        public int i
        {
            get { return _i; }
            set { _i = value; }
        }

        private Type _tipo;
        public Type Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }    

        private int _Parametro_Id;
        public int Parametro_Id
        {
            get { return _Parametro_Id; }
            set { _Parametro_Id = value; }
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

        private string _Titulo1_Reporte;
        public string Titulo1_Reporte
        {
            get { return _Titulo1_Reporte; }
            set { _Titulo1_Reporte = value; }
        }

        private SqlCommand _SqlComando;
        public SqlCommand SqlComando
        {
            get { return _SqlComando; }
            set { _SqlComando = value; }
        }
        private string _sFile;
        public string sFile
        {
            get { return _sFile; }
            set { _sFile = value; }
        }
        private SqlDataAdapter _SqlAdapter;
        public SqlDataAdapter SqlAdapter
        {
            get { return _SqlAdapter; }
            set { _SqlAdapter = value; }
        }

        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        private string _Servidor_Correo_Saliente;

        public string Servidor_Correo_Saliente
        {
            get { return _Servidor_Correo_Saliente; }
            set { _Servidor_Correo_Saliente = value; }
        }


        private SqlDataReader _SqlReader;
        public SqlDataReader SqlReader
        {
            get { return _SqlReader; }
            set { _SqlReader = value; }
        }

        //Temas para Personalizar Controles
        public string Color_TitlePanel = "#CCCCCC";
        public string Color_Row_Grid = "#FFEBD7";
        public string Color_BackColor_Grid = "#DAF1FE";
        public string Color_Panel_1 = "#DAF1FE";
        public string Color_Panel_2 = "#FFFFEC";
        public string Color_Panel_3 = "#E6FFE6";
        public string TemaGrid = "BlackGlass";
        public string TemaMenu = "Office2003Blue";
        public string TemaButton = "Aqua";
        public string TemaPopup = "PlasticBlue";
        /////


        //_____________________________________________________________________________________________________________________________________________________________________
        //PARAMETROS DE DATOS   
        public string Pagina_de_Error = "ErrorPage.aspx";
        public string Nombre_Sistema = "SILA";
        const string NBD = "SILA";
        const string NS = "SRV-DB";
        public string _Ubicacion = "aplicacionesmem";
      

       
        public string Usuarios_Administradores = "'Operadores.SILA','SupervisoresA.SILA','Autorizadores.SILA'";
        public string DocsGenerados = HttpContext.Current.Server.MapPath("~\\Procesos\\DocsGenerados\\"); //SE COPIA AHI PARA VISUALIZARLO DESDE EL SISTEMA        
        public string DocsGenerados_Server_BD = "\\" + "\\" + NS + "\\DocsGenerados\\";
        //_____________________________________________________________________________________________________________________________________________________________________
        //Local
        //public string Usuarios_Administradores = " and Usuario IN('Operadores.SILA','SupervisoresB.SILA','SupervisoresA.SILA','Autorizadores.SILA')";
        //public string DocsGenerados = HttpContext.Current.Server.MapPath("~\\Procesos\\DocsGenerados\\"); //SE COPIA AHI PARA VISUALIZARLO DESDE EL SISTEMA        
        //public string DocsGenerados_Server_BD =  HttpContext.Current.Server.MapPath("~\\Procesos\\DocsGenerados\\"); LOCAL
        //_____________________________________________________________________________________________________________________________________________________________________

      

        // public string DocsGenerados_Server_BD = "\\" + "\\10.38.91.4\\DocsGenerados\\";
        //"\\" + "\\10.38.91.4\\DocsGenerados\\"

        public NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;

      
        // Inicializar el constructor
        public General()
        {
         

            //_Conexion = new SqlConnection("Data Source=" + string.Format("{0}", appSettings.GetValues("NS")) + ";Initial Catalog=" + string.Format("{0}", appSettings.GetValues("Ndb")) + ";Persist Security Info=True;User ID=SILA_USER;Password=Sila@123");
            _Conexion = new SqlConnection("Data Source=" + string.Format("{0}", NS) + ";Initial Catalog=" + string.Format("{0}", NBD )+ ";Persist Security Info=True;User ID=SILA_USER;Password=Sila@123");

        }
        public void Ejecutar_Funcion_JavaScript(Page Pagina, Type Tipe, string KeyInstanceName, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, KeyInstanceName, "<script>" + Funcion + ";</script>", false);
        }

        public void RegisterUpdatePanel(UpdatePanel UpdatePanel, Page Page)
        {
            var sType = typeof(ScriptManager);
            var mInfo = sType.GetMethod("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mInfo != null)
                mInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { UpdatePanel });
        }

        public void Logueos_Usuarios(string Usuario)
        {
            string clientMachineName = HttpContext.Current.Request.UserHostAddress;//              
            string Sesion_Id = (DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString()).ToString();
            string perfil = Grupo(Usuario);
            ExecuteSql("INSERT INTO COMUN..Control_Acceso_Usuarios (Sesion_Id, Usuario, Perfil, FAR, PC, Aplicacion) VALUES (" + Sesion_Id + ", '" + Usuario.Trim() + "', '" + perfil + "', GETDATE(), '" + clientMachineName.Trim() + "', '" + Nombre_Sistema + "')");
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
            if (_Conexion.State == ConnectionState.Open)
            {
                _Conexion.Close();
            }
            return Retorno;
        }


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
                    else
                    {
                            Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                            Resp.Redirect("~/Error_Page.aspx", true);
                            Limpiar_Cookies(Resp);
              
                    }
                  }
              }

        }
        public void Limpiar_Label_Error()
        {
            Page PG = HttpContext.Current.Handler as Page;
            ASPxLabel lblMaster = (ASPxLabel)PG.Master.FindControl("lblMaster");
            lblMaster.Text = "";
        }

        //Nuevo Controlador Error
        

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
                if (Ex.InnerException != null)
                {
                    StackTrace stackTraceInner = new StackTrace(Ex.InnerException, true);
                    error = error + Ex.InnerException.Message.Replace("'", " ") + Environment.NewLine + "Origen:" + stackTraceInner.GetFrame(0).GetMethod().Name + Environment.NewLine + "Linea: " + stackTraceInner.GetFrame(stackTraceInner.FrameCount - 1).GetFileLineNumber();
                }
                StackTrace stackTrace = new StackTrace(Ex, true);
                error = error + Environment.NewLine + "Origen:" + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetMethod().Name + Environment.NewLine + "Linea: " + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetFileLineNumber();

                CodError = DateTime.Now.ToString("yyyy-MMddhhmmss");//Codigo unico del error para referencia del usuario


                ExecuteSql("INSERT INTO COMUN..ErroresSistema (Sistema,Descripcion, Fecha, Usuario, Pantalla,CodError) VALUES('" + Nombre_Sistema + "','" + error + "',GETDATE(),'" + usuario + "','" + NombrePagina + "','" + CodError + "')");

                //if (Ex.GetType().FullName != "System.Web.HttpUnhandledException")
                    Ejecutar_Funcion_JavaScript(PG, PG.GetType(), "err_msg", "alert('Se ha producido un error inesperado.');");

            }
        }

        public void Focus(DevExpress.Web.ASPxWebControl Ctrl)
        {
            Ctrl.SetClientSideEventHandler("Init", "function(s, e) { setTimeout(function() {s.Focus();}, 0); }");
        }

        public void Personalizar_Controles(Control Ctrl, int Opcion = 0)
        {
            if (Ctrl is ASPxMenu)
            {
                ASPxMenu Menu = (ASPxMenu)Ctrl;
                Menu.Theme = TemaButton;
            }
            else if (Ctrl is ASPxButton)
            {
                ASPxButton Button = (ASPxButton)Ctrl;
                if (Opcion == 1) //OCULTO
                {
                    Button.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_1);
                }
                else
                {
                    Button.Theme = TemaButton;
                }
            }
            else if (Ctrl is ASPxGridView)
            {
                ASPxGridView GridView = (ASPxGridView)Ctrl;
                GridView.Styles.FocusedRow.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Row_Grid);
                GridView.ControlStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_BackColor_Grid);
                GridView.SettingsText.PopupEditFormCaption = Nombre_Sistema.ToString();
                GridView.Styles.TitlePanel.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_TitlePanel);
                GridView.Theme = TemaGrid;
            }
            else if (Ctrl is ASPxPopupControl)
            {
                ASPxPopupControl PopupControl = (ASPxPopupControl)Ctrl;
                if (Ctrl.ID != "PopupMensajes")
                {
                    PopupControl.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_1);
                }
                PopupControl.HeaderText = Nombre_Sistema.ToString();
                PopupControl.HeaderImage.Url = "~/Imagenes/Usados/SF.png";
                PopupControl.Theme = TemaPopup;
            }
            else if (Ctrl is ASPxPanel)
            {
                ASPxPanel APanelP = (ASPxPanel)Ctrl;
                if (Opcion == 0 || Opcion == 1)
                {
                    APanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_1);
                }
                else if (Opcion == 2)
                {
                    APanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_2);
                }
                else if (Opcion == 3)
                {
                    APanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_3);
                }
            }
            else if (Ctrl is Panel)
            {
                Panel PanelP = (Panel)Ctrl;
                if (Opcion == 0 || Opcion == 1)
                {
                    PanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_1);
                }
                else if (Opcion == 2)
                {
                    PanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_2);
                }
                else if (Opcion == 3)
                {
                    PanelP.BackColor = System.Drawing.ColorTranslator.FromHtml(Color_Panel_3);
                }
            }
        }




        //VERIFICAR SI EL SISTEMA SE ENCUENTRA EN MANTENIMIENTO
        public Boolean Mantenimiento()
        {
            _DataSetGlobal = new DataSet();
            MakeRecordSet(_DataSetGlobal, "SELECT TOP (1) Mantenimiento FROM COMUN..Mantenimientos WHERE (Aplicacion_Id = 10) ORDER BY Mantenimiento_Id DESC", "T");
            if (_DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                return Convert.ToBoolean(_DataSetGlobal.Tables["T"].Rows[0]["Mantenimiento"].ToString());
            }
            else
            {
                return false;
            }
        }

  
        public void CargarArchivoLeer(string SqlCadenaArchivo, string fileXtension, string NameArchivo)
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
            byte[] bits = (byte[])(ds.Tables[0].Rows[0].ItemArray[0]);
            mysql1.Connection.Close();

            sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo;
            _sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo;
            //sFile = NameArchivo;
            FileStream fs = new FileStream(DocsGenerados + sFile, FileMode.Create);
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            fs.Close();
        }
        public string check_valor(string valores)
        {
            string retorno = "";
            if (valores == "True") { retorno = "1"; } else { retorno = "0"; }
            return retorno;
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

        //Funcion que permite establecer la conexion con la base de datos
        public Boolean AbrirConexion()
        {
            try
            {
                if (_Conexion.State == ConnectionState.Open)
                {
                    _Conexion.Close();
                    _Conexion.Open();
                }
                else
                {
                    _Conexion.Open();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            //NameServer =string.Format("{0}", appSettings.GetValues("NS"));

        }

        public HttpCookie CrearCokie(string Cokie, string Valor)
        {
            HttpCookie CrearCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            //CrearCokie.Expires = DateTime.Now.AddDays(-1d);
            return CrearCokie;
            
        }

        public HttpCookie EliminarCokie(string Cokie, string Valor)
        {
            HttpCookie EliminarCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            EliminarCokie.Expires = DateTime.Now.AddDays(-1d);
            return EliminarCokie;

        }

        //Procedimiento que permite abrir una pantalla modal
        public void Show_Windows(Page Pagina, Type Tipe, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, "PopupMensajes", "<script>" + Funcion + ";</script>", false);
        }

        //Procedimiento que permite cerrar una pantalla modal
        public void Close_Windows(Page Pagina, Type Tipe, string Funcion, string NameControl)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, NameControl, "<script>" + Funcion + ";</script>", false);
        }

        //Funcion que permite verificar si una sentencia Select contiene datos de retorno
        public Boolean ExistenDatos(string cadena)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }            
            SqlDataAdapter MysqlAdapter = new SqlDataAdapter(cadena, _Conexion.ConnectionString);
            DataSet Mydataset = new DataSet();
            MysqlAdapter.Fill(Mydataset, "Compuesta");
            
            _Conexion.Close();

            if (Mydataset.Tables["Compuesta"].Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        //Procedimiento que permite ejecutar una sentencia SQL
        public void ExecuteSql(string Sqlstr)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }            
            SqlCommand SqlComando = new SqlCommand();
            SqlComando.Connection = _Conexion;
            SqlComando.CommandTimeout = 0;

            if (SqlComando.Connection.State == ConnectionState.Closed)
            {
                SqlComando.Connection.Open();
            }
            SqlComando.CommandText = Sqlstr;
            SqlComando.CommandType = CommandType.Text;
            SqlComando.ExecuteReader();
            SqlComando.Connection.Close();
            _Conexion.Close();
        }

        //Recorrer una tabla o consulta
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
            _Conexion.Close();
        }

        //Recorrer una tabla o consulta
        public void MakeRecordSetExcel(DataSet MyDataSet, string Sqlstr, string NameTable, OleDbConnection Conn )
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            SqlDataAdapter MySqlAdapter = new SqlDataAdapter(Sqlstr, Conn.ConnectionString);
            if (NameTable.Length != 0)
            {
                MySqlAdapter.Fill(MyDataSet, NameTable);
            }
            else
            {
                MySqlAdapter.Fill(MyDataSet);
            }
            MyDataSet = null;
            _Conexion.Close();
        }

        //Procedimiento que permite llenar un DataSet, se utiliza para los llenados de los combos y grid
        public void FilldataSource(SqlDataSource SqlDS, string SqlstrDS)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            SqlDS.ConnectionString = Conexion.ConnectionString;
            SqlDS.SelectCommandType = SqlDataSourceCommandType.Text;
            SqlDS.SelectCommand = SqlstrDS;
            _Conexion.Close();
        }

        public void FilldataSource_DataBind(GridView Grid, string Sqlstr, object LinQ)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            if (Sqlstr != "")
            {
                SqlDataAdapter MysqlAdapter = new SqlDataAdapter(Sqlstr, Conexion);
                DataSet Mydataset = new DataSet();
                MysqlAdapter.Fill(Mydataset);
                Grid.DataSource = Mydataset.Tables[0];
            }
            else
            {
                Grid.DataSource = LinQ;
            }
            Grid.DataBind();
            _Conexion.Close();
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

        public System.Data.DataTable TBLDatos(string Sqlstr)
        {

            SqlComando = new SqlCommand();
            SqlAdapter = new SqlDataAdapter();

            SqlComando.Connection = _Conexion;
            if (SqlComando.Connection.State == ConnectionState.Closed)
            {
                SqlComando.Connection.Open();
            }


            System.Data.DataTable TBLDatos = new System.Data.DataTable();
            SqlComando.CommandType = System.Data.CommandType.Text;
            SqlComando.CommandText = Sqlstr;
            SqlAdapter.SelectCommand = SqlComando;
            SqlAdapter.Fill(TBLDatos);
            return TBLDatos;
        }
           
        ////Funcion que permite determinar el rol al que pertenece el usuario que se conecta
       
        public string Grupo(string Usuario)
        {

            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            
            string NGrupo = "";
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT Perfil FROM COMUN..vw_aspnet_UsersInRoles WHERE (Usuario = '" + Usuario + "') AND (Aplicacion = '" + Nombre_Sistema + "')", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                NGrupo = DataSetGlobal.Tables["T"].Rows[0]["Perfil"].ToString();
            }

            _Conexion.Close();
            return NGrupo;
        }


        public string Verificar_Bloqueo_Usuario(int opciones, string Login)
        {
            string valor = "";
            string proceder = "";
            string bloqueo_usuario = "SELECT LOGINPROPERTY('" + Login + "', 'IsLocked')";
            string aviso_caducacion_password = "SELECT LOGINPROPERTY('" + Login + "', 'DaysUntilExpiration')";

            if (opciones == 1) { proceder = bloqueo_usuario; }
            else if (opciones == 2) { proceder = aviso_caducacion_password; }

            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, proceder, "");
            if (DataSetGlobal.Tables[0].Rows.Count != 0)
            {
                valor = DataSetGlobal.Tables[0].Rows[0][0].ToString();
            }
            return valor;
        }

        public void Cambiar_Contraseña_SQL(string Usuario, string Password_Anterior, string Password_Nuevo)
        {
            ExecuteSql("sp_password @old =" + Password_Anterior + ", @new =" + Password_Nuevo + " , @loginame=" + Usuario + "");
        }

        public bool ValidarPassword(string Pwd)
        {
            int i = 0; bool HayNumero=false; bool HayMayuscula=false; bool HayMinuscula=false; bool HayCaracterEspecial=false;

            //Validar Longitud
            if (Pwd.Length <= 7) 
            {
                return false;                
            }
            //BUSCAR NUMERO
            for (i = 0; i < Pwd.Length; i++)
            {                                                
                if (char.IsNumber(Pwd,i)==true)
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

        public Boolean Enviar_Correo(string Remitente, string Destinatario, string Asunto, string Cuerpo_Mensaje, string copias)
        {
            try
            {
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                correo.From = new System.Net.Mail.MailAddress(Remitente);
                correo.Subject = Asunto.Trim();
                correo.To.Add(Destinatario);
                if (copias != "")
                {
                    correo.CC.Add(copias);
                }
                correo.IsBodyHtml = true;
                correo.Body = Cuerpo_Mensaje;
                correo.Priority = System.Net.Mail.MailPriority.Normal;
                smtp.Host = "10.38.91.3";
                smtp.Send(correo);
                return true;
            }
            catch (System.Net.Mail.SmtpException Ex)
            {
                return true;
            }

        }

        public void Limpiar_Cookies(HttpResponse Resp) 
        {
            Resp.Cookies.Add(EliminarCokie("NombreGrupo", ""));
            Resp.Cookies.Add(EliminarCokie("NombreUsuario", ""));
            Resp.Cookies.Add(EliminarCokie("RazonUnica", ""));
            Resp.Cookies.Add(EliminarCokie("Parametro_Id", ""));
            FormsAuthentication.SignOut();
        }

        public void Obtener_Parametros(int Parametro_id)
        {
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT Razon_Social, Titulo1_Reporte FROM Parametros WHERE (Parametro_Id = " + Parametro_id + ")", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                //_Razon_Social = DataSetGlobal.Tables["T"].Rows[0]["Razon_Social"].ToString();
                _Titulo1_Reporte = DataSetGlobal.Tables["T"].Rows[0]["Titulo1_Reporte"].ToString();
            }
            DataSetGlobal.Clear();
        }
        
        public string Buscar_Id_combo(string descripcion, int Opcion)
        {
            string Retorno = "";
            string StrQuery = "";
            string Consulta_Indice = "SELECT Indice_Catalogo_Id FROM Indice_Catalogo WHERE Descripcion='" + descripcion + "'";
            string Consulta_Unidad_Generacion = "SELECT Generador_Id FROM Generadores WHERE Nombre='" + descripcion + "'";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (Opcion == 1)//CONSULTAMOS EL INDEX DEL COMBOBOX INDICE
            {
                StrQuery = Consulta_Indice;
            }
            else if (Opcion == 2)//CONSULTAMOS EL INDEX DEL COMBOBOX UnidadGeneracion
            {
                StrQuery = Consulta_Unidad_Generacion;
            }



            /////////////////////////////////////////////////////////////////////////////
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, StrQuery, "");
            if (DataSetGlobal.Tables[0].Rows.Count != 0)
            {
                Retorno = DataSetGlobal.Tables[0].Rows[0][0].ToString();
            }
            DataSetGlobal.Dispose();







            return Retorno;
        }

        public void ObtenerParametrosComun()
        {
            //DataSet DataSetGlobal = new DataSet();
            //MakeRecordSet(DataSetGlobal, "SELECT * FROM VW_PARAMETROS_COMUN", "T");
            //if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            //{
            //    //_Ubicacion = DataSetGlobal.Tables["T"].Rows[0]["Ubicacion"].ToString();
            //    //_Servidor_Correo_Saliente =  DataSetGlobal.Tables["T"].Rows[0]["Servidor_Correo_Saliente"].ToString();
            //}
            //DataSetGlobal.Clear();
        }

        public string Acceso_Sistema(HttpResponse Resp, HttpRequest Req, string Usuario, string Perfil, string Pantalla)
        {
            try
            {
                //PREGUNTAR POR LA CO0KIE DE SESION
                HttpCookie authCookie = Req.Cookies[FormsAuthentication.FormsCookieName];
                if (Req.Cookies.Get("NombreGrupo").Value == null)
                {
                    return "Ninguno";
                }
                else if (authCookie == null)
                {
                    return "TimeOut";
                }
                else
                {
                   return "Si";
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


        public string Obtener_Mensaje_SQL(string Identidad_User)
        {

            string MensajeErrSQL="";
            DataSet ErroresSQL = new DataSet();
            MakeRecordSet(ErroresSQL, "select DISTINCT(ISNULL(Error,'')) AS Error from ErrorSQL WHERE Identidad_User='" + Identidad_User + "' AND ISNULL(Error,'') <> ''", "");
            if (ErroresSQL.Tables[0].Rows.Count != 0)
            {
                MensajeErrSQL = (ErroresSQL.Tables[0].Rows[0][0].ToString().Trim());
                //ExecuteSql("DELETE FROM ErrorSQL WHERE Identidad_User='" + Identidad_User + "'");
            }
            return MensajeErrSQL;
        }

        //FUNCION PARA EJECUTAR UN PROCEDIMIENTO UTILIZANDO LA VARIABLE _SQLCOMMAND, ESTA VARIABLE DEBE ESTAR CON LOS PARAMETROS INGRESADOS ANTES DE EJECUTAR DICHA FUNCION
        public object EjecutarProcedimiento()
        {

            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
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

        public Boolean ValidarContraseña_Historico(string Usuario, string NuevaContraseña)
        {
            Boolean Retorno = true;
            DataSet Historico = new DataSet();
            MakeRecordSet(Historico, "SELECT [Password],[PasswordSalt],[Date] FROM [COMUN].[dbo].[Membership_Pasword_Log] WHERE UserName='"+ Usuario + "'", "");
            if (Historico.Tables[0].Rows.Count != 0)
            {
                for (int i=0; i<Historico.Tables[0].Rows.Count;i++)
                {
                    //Aplico el PasswordSalt de las contraseñas almacenadas en el historico a la Nueva Contraseña
                    string NuevaContraseña_Salt = GenerateHash(NuevaContraseña, Historico.Tables[0].Rows[i]["PassWordSalt"].ToString());
                    //Comparo la Nueva Contraseña una vez aplicado el Hash con las Contraseñas Almacenadas
                    if (NuevaContraseña_Salt == Historico.Tables[0].Rows[i]["Password"].ToString())
                        return false;

                }
            }

            return Retorno;
        }

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