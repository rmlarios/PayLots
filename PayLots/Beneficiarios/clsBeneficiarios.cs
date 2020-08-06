using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Beneficiarios
{
    public class clsBeneficiarios
    {
        private int _IdBeneficiario;
        public int IdBeneficiario
        {
            get { return _IdBeneficiario; }
            set { _IdBeneficiario = value; }
        }

        private string _NombreCompleto;
        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set { _NombreCompleto = value; }
        }

        private string _CedulaIdentidad;
        public string CedulaIdentidad
        {
            get { return _CedulaIdentidad; }
            set { _CedulaIdentidad = value; }
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
    }
}