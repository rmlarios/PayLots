using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayLots.Lotes;
using PayLots.Beneficiarios;
using PayLots.Ubicaciones;
using PayLots.Asignaciones;
using PayLots.Pagos;
using PayLots.Configuraciones;
using PayLots.Moras;
using PayLots.Clases;
using cls_GENERAL;
using System.Data;


namespace PayLots.Clases
{
   
    public class Negocio
    {
        public Cls_General FG = new Cls_General();
        #region::::::::::::::::::UBICACIONES:::::::::::::::::::::::
        public void AgregarActualizarUbicacion(clsUbicaciones Ubicacion, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_UbicacionCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdUbicacion", SqlDbType.Int, Ubicacion.IdUbicacion);
            FG.AgregarParametroProcedimiento("@IdMunicipio", SqlDbType.Int, Ubicacion.IdMunicipio);
            FG.AgregarParametroProcedimiento("@NombreProyecto", SqlDbType.NVarChar, Ubicacion.NombreProyecto);
            FG.AgregarParametroProcedimiento("@Direccion", SqlDbType.NVarChar, Ubicacion.Direccion);
            FG.AgregarParametroProcedimiento("@AplicaInteres", SqlDbType.Bit, Ubicacion.AplicaInteres);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }

        public void EliminarUbicacion(int IdUbicacion, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_UbicacionEliminar");
            FG.AgregarParametroProcedimiento("@IdUbicacion", SqlDbType.Int, IdUbicacion);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::
        #region::::::::::::::::::::BLOQUES::::::::::::::::::::
        public void AgregarActualizarBloque(clsBloques Bloque, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_BloqueCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdBloque", SqlDbType.Int, Bloque.IdBloque);
            FG.AgregarParametroProcedimiento("@IdUbicacion", SqlDbType.Int, Bloque.IdUbicacion);
            FG.AgregarParametroProcedimiento("@Bloque", SqlDbType.NVarChar,Bloque.Bloque);
            FG.AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Bloque.Observaciones);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }

        public void EliminarBloque(int IdBloque, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_BloqueEliminar");
            FG.AgregarParametroProcedimiento("@IdBloque", SqlDbType.Int, IdBloque);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::LOTES:::::::::::::::::::::::::::::
        public void AgregarActualizarLote(clsLotes Lote,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_LoteCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdLote", SqlDbType.Int, Lote.IdLote);
            FG.AgregarParametroProcedimiento("@IdBloque", SqlDbType.Int, Lote.IdBloque);
            FG.AgregarParametroProcedimiento("@NumeroLote", SqlDbType.NVarChar, Lote.NumeroLote);
            FG.AgregarParametroProcedimiento("@Area", SqlDbType.Float, Lote.Area);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar,UUA);
            FG.EjecutarProcedimiento();
        }

        public void EliminarLote(int IdLote, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_LoteEliminar");
            FG.AgregarParametroProcedimiento("@IdLote", SqlDbType.Int, IdLote);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::BENEFICIARIOS:::::::::::::::::::::
        public string AgregarActualizarBeneficiario(clsBeneficiarios Beneficiario, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return "0"; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_BeneficiarioCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdBeneficiario", SqlDbType.Int, Beneficiario.IdBeneficiario);
            FG.AgregarParametroProcedimiento("@NombreCompleto", SqlDbType.NVarChar, Beneficiario.NombreCompleto);
            FG.AgregarParametroProcedimiento("@CedulaIdentidad", SqlDbType.NVarChar, Beneficiario.CedulaIdentidad);
            FG.AgregarParametroProcedimiento("@Direccion", SqlDbType.NVarChar, Beneficiario.Direccion);
            FG.AgregarParametroProcedimiento("@Telefono", SqlDbType.NVarChar, Beneficiario.Telefono);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
           //EJECUTO EL PROCEDIMIENTO
            var Retorno = FG.EjecutarProcedimiento();
            string IdRetorno = "0";
            if (Retorno != null)
            {
                IdRetorno = Retorno.ToString();
            }
            return IdRetorno;
        }

        public void EliminarBeneficiario(int IdBeneficiario, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_BeneficiarioEliminar");
            FG.AgregarParametroProcedimiento("@IdBeneficiarfio", SqlDbType.Int, IdBeneficiario);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::::::::ASIGNACIONES::::::::::::::::::::::::
        public string AgregarActualizarAsignacion(clsAsignaciones Asignacion, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return "0"; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_AsignacionCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdAsignacion", SqlDbType.Int, Asignacion.IdAsignacion);
            FG.AgregarParametroProcedimiento("@IdLote", SqlDbType.Int, Asignacion.IdLote);
            FG.AgregarParametroProcedimiento("@IdBeneficiario", SqlDbType.Int, Asignacion.IdBeneficiario);
            FG.AgregarParametroProcedimiento("@FechaInicioPago", SqlDbType.DateTime, Asignacion.FechaInicioPago);
            FG.AgregarParametroProcedimiento("@MontoTotal", SqlDbType.Float, Asignacion.MontoTotal);
            FG.AgregarParametroProcedimiento("@CuotaMinima", SqlDbType.Float, Asignacion.CuotaMinima);
            FG.AgregarParametroProcedimiento("@Prima", SqlDbType.Float, Asignacion.Prima);
            FG.AgregarParametroProcedimiento("@Donado", SqlDbType.Bit, Asignacion.Donado);
            FG.AgregarParametroProcedimiento("@AplicaMora", SqlDbType.Bit, Asignacion.AplicaMora);
            FG.AgregarParametroProcedimiento("@AplicaInteres", SqlDbType.Bit, Asignacion.AplicaInteres);
            FG.AgregarParametroProcedimiento("@TasaInteres", SqlDbType.Float, Asignacion.TasaInteres);
            FG.AgregarParametroProcedimiento("@PlazoMeses", SqlDbType.Int, Asignacion.PlazoMeses);
            FG.AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Asignacion.Observaciones);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            //EJECUTO EL PROCEDIMIENTO
            var Retorno = FG.EjecutarProcedimiento();
            string IdRetorno = "0";
            if (Retorno != null)
            {
                IdRetorno = Retorno.ToString();
            }
            return IdRetorno;
        }
        public void AnularAsignacion(int IdAsignacion,string Motivo, string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_AsignacionAnular");
            FG.AgregarParametroProcedimiento("@IdAsignacion", SqlDbType.Int, IdAsignacion);
            FG.AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Motivo);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar,IdentityUser);
            FG.EjecutarProcedimiento();

        }
        public clsAsignaciones CargarAsignacion(string IdAsignacion)
        {
            clsAsignaciones Asignacion = new clsAsignaciones();
            DataSet ObtenerDatos = new DataSet();
            FG.MakeRecordSet(ObtenerDatos, "SELECT [IdAsignacion],[IdLote],[NombreLote],[IdBeneficiario],[NombreCompleto],[MontoTotal],[FechaInicioPago],[CuotaMinima],[Estado],[Donado],[Abonado],ISNULL([Prima],0) Prima,[Saldo],[AplicaInteres],[Observaciones],[AplicaMora],[TasaInteres],[Plazo] FROM [View_Asignaciones_Saldo] WHERE IdAsignacion='" + IdAsignacion +"'", "");
            if (ObtenerDatos.Tables[0].Rows.Count != 0)
            {
                Asignacion.IdAsignacion = Convert.ToInt32(ObtenerDatos.Tables[0].Rows[0]["IdAsignacion"].ToString());
                Asignacion.IdLote = Convert.ToInt32(ObtenerDatos.Tables[0].Rows[0]["IdLote"].ToString());
                Asignacion.IdBeneficiario = Convert.ToInt32(ObtenerDatos.Tables[0].Rows[0]["IdBeneficiario"].ToString());
                Asignacion.MontoTotal = Convert.ToDouble(ObtenerDatos.Tables[0].Rows[0]["MontoTotal"].ToString());
                Asignacion.CuotaMinima = Convert.ToDouble(ObtenerDatos.Tables[0].Rows[0]["CuotaMinima"].ToString());
                Asignacion.Prima = Convert.ToDouble(ObtenerDatos.Tables[0].Rows[0]["Prima"].ToString());
                Asignacion.FechaInicioPago = ObtenerDatos.Tables[0].Rows[0]["FechaInicioPago"].ToString() != "" ? Convert.ToDateTime(ObtenerDatos.Tables[0].Rows[0]["FechaInicioPago"]):(DateTime?)null;
                Asignacion.Observaciones = ObtenerDatos.Tables[0].Rows[0]["Observaciones"].ToString();
                Asignacion.Donado = Convert.ToBoolean(ObtenerDatos.Tables[0].Rows[0]["Donado"]);
                Asignacion.AplicaInteres = ObtenerDatos.Tables[0].Rows[0]["AplicaInteres"].ToString()!=""?Convert.ToBoolean(ObtenerDatos.Tables[0].Rows[0]["AplicaInteres"].ToString()):false;
                Asignacion.AplicaMora = Convert.ToBoolean(ObtenerDatos.Tables[0].Rows[0]["AplicaInteres"]);
                Asignacion.TasaInteres = Convert.ToDouble(ObtenerDatos.Tables[0].Rows[0]["TasaInteres"].ToString());
                Asignacion.PlazoMeses = Convert.ToInt32(ObtenerDatos.Tables[0].Rows[0]["Plazo"].ToString());
                
            }
            else
            {
                Asignacion.IdAsignacion = 0;
            }
            return Asignacion;
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region::::::::::::::::::PAGOS::::::::::::::::::::::::
        public string AgregarActualizarPago(clsPagos Pago,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return "0"; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_PagoCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdPago", SqlDbType.Int, Pago.IdPago);
           
            FG.AgregarParametroProcedimiento("@IdAsignacion", SqlDbType.Int, Pago.IDAsignacion);
            FG.AgregarParametroProcedimiento("@NumeroRecibo", SqlDbType.NVarChar, Pago.NumeroRecibo);
            FG.AgregarParametroProcedimiento("@FechaRecibo", SqlDbType.DateTime, Pago.FechaRecibo);
            FG.AgregarParametroProcedimiento("@MesPagado", SqlDbType.NVarChar, Pago.MesPagado);
            FG.AgregarParametroProcedimiento("@Moneda", SqlDbType.NVarChar, Pago.Moneda);
            FG.AgregarParametroProcedimiento("@TasaCambio", SqlDbType.Float, Pago.TasaCambio);
            FG.AgregarParametroProcedimiento("@MontoPago", SqlDbType.Float, Pago.MontoPago);
            FG.AgregarParametroProcedimiento("@Mora", SqlDbType.Float, Pago.Mora);
            FG.AgregarParametroProcedimiento("@Interes", SqlDbType.Float, Pago.Interes);
            FG.AgregarParametroProcedimiento("@TotalPagado", SqlDbType.Float, Pago.TotalPagado);
            FG.AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Pago.Observaciones);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            string IdRetorno = "0";
            var Retorno = FG.EjecutarProcedimiento();
            if(Retorno!=null)
            {
                IdRetorno = Retorno.ToString();
            }
            

            return IdRetorno;
        }
        public void EliminarPago(string IdPago,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_PagoEliminar");
            FG.AgregarParametroProcedimiento("@IdPago", SqlDbType.Int, IdPago);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.EjecutarProcedimiento();
        }
      
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::::::REPORTES:::::::::::::::::::::::::::::::::::


        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::::::CONFIGURACIONES:::::::::::::::::::::::
        public void AgregarActualizarDatosEmpresa(clsDatosEmpresa DatosEmpresa,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_DatosEmpresaCrearActualizar");
            FG.AgregarParametroProcedimiento("@NombreEmpresa", SqlDbType.NVarChar, DatosEmpresa.NombreEmpresa);
            FG.AgregarParametroProcedimiento("@Direccion", SqlDbType.NVarChar, DatosEmpresa.Direccion);
            FG.AgregarParametroProcedimiento("@Telefono", SqlDbType.NVarChar, DatosEmpresa.Telefono);
            FG.AgregarParametroProcedimiento("@Email", SqlDbType.NVarChar, DatosEmpresa.Email);
            FG.AgregarParametroProcedimiento("@Ruc", SqlDbType.NVarChar, DatosEmpresa.Ruc);
            if(DatosEmpresa.Logo != null)
                FG.AgregarParametroProcedimiento("@Logo", SqlDbType.Image, DatosEmpresa.Logo);
            else
                FG.AgregarParametroProcedimiento("@Logo", SqlDbType.Image, DBNull.Value);

            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.EjecutarProcedimiento();

        }
        public clsDatosEmpresa CargarDatosEmpresa()
        {
            clsDatosEmpresa DatosEmpresa = new clsDatosEmpresa();
            DataSet Datos = new DataSet();
            FG.MakeRecordSet(Datos, "SELECT * FROM DatosEmpresa", "");
            if (Datos.Tables[0].Rows.Count != 0)
            {
                DatosEmpresa.NombreEmpresa = Datos.Tables[0].Rows[0]["NombreEmpresa"].ToString();
                DatosEmpresa.Direccion = Datos.Tables[0].Rows[0]["Direccion"].ToString();
                DatosEmpresa.Telefono = Datos.Tables[0].Rows[0]["Telefono"].ToString();
                DatosEmpresa.Email = Datos.Tables[0].Rows[0]["Email"].ToString();
                DatosEmpresa.Ruc = Datos.Tables[0].Rows[0]["Ruc"].ToString();
                if (Datos.Tables[0].Rows[0]["Logo"] != System.DBNull.Value)
                    DatosEmpresa.Logo = (byte[])Datos.Tables[0].Rows[0]["Logo"];
            }
            else
                DatosEmpresa.NombreEmpresa = "Empty";

            return DatosEmpresa;
        }
        public void AgregarActualizarAvatar(byte[] Image,string IdentityUser)
        {

        }
        #endregion
        #region::::::::::::::::::::::RANGOS MORA:::::::::::::::::::::::
        public void AgregarActualizarMora(clsMoras Mora,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_MorasCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdMora", SqlDbType.Int, Mora.IdMora);
            FG.AgregarParametroProcedimiento("@Minimo", SqlDbType.Int, Mora.Minimo);
            FG.AgregarParametroProcedimiento("@Maximo", SqlDbType.Int,Mora.Maximo);
            FG.AgregarParametroProcedimiento("@Porcentaje", SqlDbType.Float, Mora.Porcentaje);
           
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.EjecutarProcedimiento();
        }

        public void EliminarMora (int IdMora,string IdentityUser)
        {
            if (HttpContext.Current.User == null) { return; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_MorasEliminar");
            FG.AgregarParametroProcedimiento("@IdMora", SqlDbType.Int,IdMora);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            FG.EjecutarProcedimiento();
        }
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::::::PROFORMAS:::::::::::::::::::::::::
        public string AgregarActualizarProforma(clsProformas Proforma, string IdentityUser)
        {
           if (HttpContext.Current.User == null) { return "0"; }
            string UUA = HttpContext.Current.User.Identity.Name;
            FG.IniciarProcedimiento("SP_ProformaCrearActualizar");
            FG.AgregarParametroProcedimiento("@IdProforma", SqlDbType.Int, Proforma.IdProforma);
            FG.AgregarParametroProcedimiento("@Nombre", SqlDbType.NVarChar, Proforma.Nombre);
            FG.AgregarParametroProcedimiento("@Domicilio", SqlDbType.NVarChar, Proforma.Domicilio);
            FG.AgregarParametroProcedimiento("@Telefono", SqlDbType.NVarChar, Proforma.Telefono);
            FG.AgregarParametroProcedimiento("@Email", SqlDbType.NVarChar, Proforma.Email);
            FG.AgregarParametroProcedimiento("@Proyecto", SqlDbType.NVarChar, Proforma.Proyecto);
            FG.AgregarParametroProcedimiento("@Lote", SqlDbType.NVarChar, Proforma.Lote);
            FG.AgregarParametroProcedimiento("@Area", SqlDbType.Decimal, Proforma.Area);
            FG.AgregarParametroProcedimiento("@PrecioVara", SqlDbType.Decimal, Proforma.PrecioVara);
            FG.AgregarParametroProcedimiento("@Prima", SqlDbType.Decimal, Proforma.Prima);
            FG.AgregarParametroProcedimiento("@Interes", SqlDbType.Int, Proforma.Interes);
            FG.AgregarParametroProcedimiento("@Plazo", SqlDbType.Int, Proforma.Plazo);
            FG.AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            FG.AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);

            string IdRetorno = "0";
            var Retorno = FG.EjecutarProcedimiento();
            if (Retorno != null)
            {
                IdRetorno = Retorno.ToString();
            }


            return IdRetorno;
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::
    }
}