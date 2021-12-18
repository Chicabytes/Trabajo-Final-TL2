using System;
using System.Collections.Generic;
using System.Text;

namespace tp6
{
    public class Persona
    {
        private string nombre;
        private string direccion;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public Persona()
        {
            Nombre = "";
            Direccion = "";
            Telefono = "";
        }
        public Persona(string _Nombre, string _Direccion, string _Telefono)
        {
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }
    }
}
