using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_contactos
    {
        private int _ID;
        private string _Nombres;
        private string _Apellidos;
        private string _Cedula;
        private string _Correo;
        private string _Telefono1;
        private string _Telefono2;   
        private DateTime _FechaNacimiento;
        private string _Direccion;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Telefono1 { get => _Telefono1; set => _Telefono1 = value; }
        public string Telefono2 { get => _Telefono2; set => _Telefono2 = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
    }
}
