using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tp6.Addon;
using tp6.Models;

namespace tp6.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserLogueado = GetRol();
            ViewBag.NombreUserLogueado = GetUser();
            RepoUsuario repo = new RepoUsuario();
            User NUser = new User();
            NUser.Usuario = GetUser();
            NUser.Contrasena = GetPass();
            if (IsSesionIniciada() && repo.Validacion(NUser))
            {
                return View();
            }
            else
            {
                return Redirect("../User");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
