using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Ubicaciones
{
    public class clsBloques
    {
        private int _IdBloque;
        public int IdBloque
        {
            get { return _IdBloque; }
            set { _IdBloque = value; }
        }

        private int _IdUbicacion;
        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }

        private string _Bloque;
        public string Bloque
        {
            get { return _Bloque; }
            set { _Bloque = value; }
        }


        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

    }
}