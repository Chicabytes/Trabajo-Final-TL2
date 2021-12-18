using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Addon;


namespace tp6.Controllers
{
    public class BaseController : Controller
    {
        internal void SetSesion(User usuarioLogueado)
        {
            if (!IsSesionIniciada())
            {
                if (usuarioLogueado != null)
                {
                    HttpContext.Session.SetString("Usuario", usuarioLogueado.Usuario);
                    HttpContext.Session.SetString("Contrasena", usuarioLogueado.Contrasena);
                    HttpContext.Session.SetInt32("idUsuario", (int)usuarioLogueado.Id);
                    HttpContext.Session.SetInt32("Rol", (int)usuarioLogueado.Rol);
                }
            }
        }

        internal bool IsSesionIniciada()
        {
            return (HttpContext.Session.GetString("Usuario") != null);
        }

        internal int GetRol()
        {
            int rol = 0;
            if (IsSesionIniciada())
            {
                rol = (int)HttpContext.Session.GetInt32("Rol");
            }
            else
            {
                rol = -1;
            }
            return rol;
        }
        internal string GetUser()
        {
            return HttpContext.Session.GetString("Usuario");
        }
        protected string GetPass()
        {
            return HttpContext.Session.GetString("Contrasena");
        }
        internal int GetIdUsuario()
        {
            return (int)HttpContext.Session.GetInt32("idUsuario");
        }

        internal void Logout()
        {
            HttpContext.Session.Remove("Usuario");
            HttpContext.Session.Remove("Rol");
            HttpContext.Session.Remove("idUsuario");
        }
    }
}
