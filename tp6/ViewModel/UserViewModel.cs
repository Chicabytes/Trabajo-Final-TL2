using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Addon;

namespace tp6.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public Roles Rol { get; set; }
    }
}
