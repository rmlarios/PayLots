using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Moras
{
    public class clsMoras
    {
        private int _IdMora;
        public int IdMora
        {
            get { return _IdMora; }
            set { _IdMora = value; }
        }

        private int _Minimo;
        public int Minimo
        {
            get { return _Minimo; }
            set { _Minimo = value; }
        }

        private int _Maximo;
        public int Maximo
        {
            get { return _Maximo; }
            set { _Maximo = value; }
        }

        private Double _Porcentaje;
        public Double Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }
    }
}