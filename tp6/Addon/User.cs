using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Addon
{
    public enum Roles
    {
        Administrador = 0,
        Cadete = 1,
        Cliente = 2
    }
    public class User
    {
        private int id;
        private string usuario;
        private string contrasena;
        private Roles rol;

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public Roles Rol { get => rol; set => rol = value; }
    }
}
