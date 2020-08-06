using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Lotes
{
    public class clsLotes
    {
        private int _IdLote;
        public int IdLote
        {
            get { return _IdLote; }
            set { _IdLote = value; }
        }

        private int _IdBloque;
        public int IdBloque
        {
            get { return _IdBloque; }
            set { _IdBloque = value; }
        }

        private string _NumeroLote;
        public string NumeroLote
        {
            get { return _NumeroLote; }
            set { _NumeroLote = value; }
        }

        private double _Area;
        public double Area
        {
            get { return _Area; }
            set { _Area = value; }

        }

        
    }
}