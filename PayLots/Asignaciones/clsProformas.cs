using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Asignaciones
{
    public class clsProformas
    {
        private int _IdProforma;
        public int IdProforma
        {
            get { return _IdProforma; }
            set { _IdProforma = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Domicilio;
        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private string _Telefono;
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Proyecto;
        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        private string _Lote;
        public string Lote
        {
            get { return _Lote; }
            set { _Lote = value; }
        }

        private Double _Area;
        public Double Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        private Double _PrecioVara;
        public Double PrecioVara
        {
            get { return _PrecioVara; }
            set { _PrecioVara = value; }
        }

        private Double _Prima;
        public Double Prima
        {
            get { return _Prima; }
            set { _Prima = value; }
        }

        private int _Plazo;
        public int Plazo
        {
            get { return _Plazo; }
            set { _Plazo = value; }
        }

        private int _Interes;
        public int Interes
        {
            get { return _Interes; }
            set { _Interes = value; }
        }


    }
}