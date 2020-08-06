using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Asignaciones
{
    public class clsAsignaciones
    {
        /* @IdAsignacion INT,
 @IdLote                 INT,
 @IdBeneficiario INT,
 @FechaInicioPago        SMALLDATETIME,
 @MontoTotal NUMERIC(18,2),
 @CuotaMinima NUMERIC(18,2),
 @Estado NVARCHAR(MAX),
 @Donado BIT,
 @Observaciones          NVARCHAR(MAX),*/

        private int _IdAsignacion;
        public int IdAsignacion
        {
            get { return _IdAsignacion; }
            set { _IdAsignacion = value; }
        }

        private int _IdLote;
        public int IdLote
        {
            get { return _IdLote; }
            set { _IdLote = value; }
        }

        private int _IdBeneficiario;
        public int IdBeneficiario
        {
            get { return _IdBeneficiario; }
            set { _IdBeneficiario = value; }
        }

        private DateTime? _FechaInicioPago;
        public DateTime? FechaInicioPago
        {
            get { return _FechaInicioPago; }
            set { _FechaInicioPago = value; }
        }

        private Double _MontoTotal;
        public Double MontoTotal
        {
            get { return _MontoTotal; }
            set { _MontoTotal = value; }
        }

        private Double _CuotaMinima;
        public Double CuotaMinima
        {
            get { return _CuotaMinima; }
            set { _CuotaMinima = value; }
        }

        private Double _Prima;
        public Double Prima
        {
            get { return _Prima; }
            set { _Prima = value; }
        }

        private Boolean _Donado;
        public Boolean Donado
        {
            get { return _Donado; }
            set { _Donado = value; }
        }

        private Boolean _AplicaInteres;
        public Boolean AplicaInteres
        {
            get { return _AplicaInteres; }
            set { _AplicaInteres = value; }
        }

        private Double _TasaInteres;
        public Double TasaInteres
        {
            get { return _TasaInteres; }
            set { _TasaInteres = value; }
        }

        private int _PlazoMeses;
        public int PlazoMeses
        {
            get { return _PlazoMeses; }
            set { _PlazoMeses = value; }
        }

        private Boolean _AplicaMora;
        public Boolean AplicaMora
        {
            get { return _AplicaMora; }
            set { _AplicaMora = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
    }
}