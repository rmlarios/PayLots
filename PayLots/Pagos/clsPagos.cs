using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Pagos
{
    public class clsPagos
    {
        /*
         [IdPago]
      ,[IdAsignacion]
      ,[NumeroAbono]
      ,[NumeroRecibo]
      ,[FechaRecibo]
      ,[MesPagado]
      ,[MontoPago]
      ,[Mora]
      ,[Observaciones]
      ,[UAR]
      ,[FAR]
      ,[UUA]
      ,[FUA]
         */

        private int _IdPago;
        public int IdPago
        {
            get { return _IdPago; }
            set { _IdPago = value; }
        }

        private int _IdAsignacion;
        public int IDAsignacion
        {
            get { return _IdAsignacion; }
            set { _IdAsignacion = value; }
        }

        private int _NumeroAbono;
        public int NumeroAbono
        {
            get { return _NumeroAbono; }
            set { _NumeroAbono = value; }
        }

        private string _NumeroRecibo;
        public string NumeroRecibo
        {
            get { return _NumeroRecibo; }
            set { _NumeroRecibo = value; }
        }

        private DateTime? _FechaRecibo;
        public DateTime? FechaRecibo
        {
            get { return _FechaRecibo; }
            set { _FechaRecibo = value; }
        }

        private string _MesPagado;
        public string MesPagado
        {
            get { return _MesPagado; }
            set { _MesPagado = value; }
        }

        private Double _MontoPago;
        public Double MontoPago
        {
            get { return _MontoPago; }
            set { _MontoPago = value; }
        }

        private Double _Interes;
        public Double Interes
        {
            get { return _Interes; }
            set { _Interes = value; }
        }
        private Double _Mora;
        public Double Mora
        {
            get { return _Mora; }
            set { _Mora = value; }
        }

        private Double _TotalPagado;
        public Double TotalPagado
        {
            get { return _TotalPagado; }
            set { _TotalPagado = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _Moneda;
        public string Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private Double _TasaCambio;
        public Double TasaCambio
        {
            get { return _TasaCambio; }
            set { _TasaCambio = value; }
        }
            
    }
}