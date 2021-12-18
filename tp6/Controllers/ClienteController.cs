using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using tp6.Models;
using tp6.ViewModel;

namespace tp6.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;

        public ClienteController(ILogger<ClienteController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 2))
            {
                RepoClientes repo = new RepoClientes();
                List<Cliente> ListaClientes = repo.GetAll();
                List<ClienteViewModel> ClientesVM = _mapper.Map<List<ClienteViewModel>>(ListaClientes);
                return View(ClientesVM);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult CargaCliente(ClienteViewModel _Cli)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 2))
            {
                try
                {
                    RepoClientes repo = new RepoClientes();
                    Cliente Cli = _mapper.Map<Cliente>(_Cli);
                    repo.Alta(Cli);
                    return Redirect("/Cliente/Index");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        public IActionResult AltaCliente(int idUser)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 2))
            {
                return View(new ClienteViewModel() { IdCliente = idUser});
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult BajaCliente(int _id)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                try
                {
                    RepoClientes repo = new RepoClientes();
                    repo.Baja(_id);
                    return Redirect("/Cliente/Index");
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return Content(error);
                }
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        public IActionResult ModificarCliente(int _id)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                RepoClientes repo = new RepoClientes();
                Cliente Cli = repo.Buscar(_id);
                ClienteViewModel cliente = _mapper.Map<ClienteViewModel>(Cli);
                return View(cliente);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult Modificar(ClienteViewModel _Cli)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                RepoClientes repo = new RepoClientes();
                Cliente Cli = _mapper.Map<Cliente>(_Cli);
                repo.Modificar(Cli);
                return Redirect("/Cliente/Index");
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
