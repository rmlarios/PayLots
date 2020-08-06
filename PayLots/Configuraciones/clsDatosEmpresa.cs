using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Configuraciones
{
    public class clsDatosEmpresa
    {
        private string _NombreEmpresa;
        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
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

        private string _Ruc;
        public string Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }

        private byte[] _Logo;
        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }
    }
}