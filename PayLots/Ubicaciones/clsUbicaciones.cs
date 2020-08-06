using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayLots.Ubicaciones
{
    public class clsUbicaciones
    {
        private int _IdUbicacion;
        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }

        private int _IdMunicipio;
        public int IdMunicipio
        {
            get { return _IdMunicipio; }
            set { _IdMunicipio = value; }
        }

        private string _NombreProyecto;
        public string NombreProyecto
        {
            get { return _NombreProyecto; }
            set { _NombreProyecto = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private Boolean _AplicaInteres;
        public Boolean AplicaInteres
        {
            get { return _AplicaInteres; }
            set { _AplicaInteres = value; }
        }

    }
}