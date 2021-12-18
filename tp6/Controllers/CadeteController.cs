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
    public class CadeteController : BaseController
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper _mapper;

        public CadeteController(ILogger<CadeteController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                RepoCadetes repo = new RepoCadetes();
                List<Cadete> ListaCadetes = repo.GetAll();
                List<CadeteViewModel> ListaVM = _mapper.Map<List<CadeteViewModel>>(ListaCadetes);
                return View(ListaVM);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        public IActionResult AltaCadete(int idUser)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                return View(new CadeteViewModel() { Id = idUser});
            }
            else
            {
                return Redirect("../Home/Index");
            }

        }
        [HttpPost]
        public IActionResult CargaCadete(CadeteViewModel _Cad)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                try
                {
                    RepoCadetes repo = new RepoCadetes();
                    Cadete cad = _mapper.Map<Cadete>(_Cad);
                    repo.Alta(cad);
                    return Redirect("/Cadete/Index");
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
        [HttpPost]
        public IActionResult BajaCadete(int _id)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                try
                {
                    RepoCadetes repo = new RepoCadetes();
                    repo.Baja(_id);
                    return Redirect("/Cadete/Index");
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
        public IActionResult ModificarCadete(int _id)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                RepoCadetes repo = new RepoCadetes();
                CadeteViewModel cad = _mapper.Map<CadeteViewModel>(repo.Buscar(_id));
                return View(cad);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult Modificar(CadeteViewModel _cad)
        {
            if (IsSesionIniciada() && GetRol() == 0)
            {
                RepoCadetes repo = new RepoCadetes();
                Cadete cad = _mapper.Map<Cadete>(_cad);
                repo.Modificar(cad);
                return Redirect("/Cadete/Index");
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult GestionDePedidos(int idCadete, TipoTransporte tipo)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                CadetesYPedidosViewModel Cadetes = new CadetesYPedidosViewModel();
                {
                    Cadetes.IdCadete = idCadete;
                    switch (tipo)
                    {
                        case TipoTransporte.Auto:
                            Cadetes.TipoPed = TipoPedido.Delicado;
                            break;
                        case TipoTransporte.Moto:
                            Cadetes.TipoPed = TipoPedido.Express;
                            break;
                        case TipoTransporte.Bicicleta:
                            Cadetes.TipoPed = TipoPedido.Ecologico;
                            break;
                    }
                }
                return View(Cadetes);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult MisPedidos(int idCadete, TipoPedido TipoP)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                CadetesYPedidosViewModel CadetesYPedidosVM = new CadetesYPedidosViewModel();
                RepoPedidos repo = new RepoPedidos();
                CadetesYPedidosVM.ListaPedidos = repo.GetAll(TipoP, idCadete);
                return View(CadetesYPedidosVM);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        [HttpPost]
        public IActionResult ListaDePedidos(int idCadete, TipoPedido TipoP)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                RepoPedidos repo = new RepoPedidos();
                CadetesYPedidosViewModel CadetesYPedidosVM = new CadetesYPedidosViewModel()
                {
                    ListaPedidos = repo.GetAll(TipoP),
                    IdCadete = idCadete
                };
                return View(CadetesYPedidosVM);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        public IActionResult ModificarEstado(int idCadete, int idPedido, EstadoPedido estado)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                CadetesYPedidosViewModel CyPedidoVM = new CadetesYPedidosViewModel()
                {
                    Estado = estado,
                    IdPedido = idPedido,
                    IdCadete = idCadete
                };
                return View(CyPedidoVM);
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }

        public IActionResult NuevoEstado(CadetesYPedidosViewModel CadyPed)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                RepoPedidos repo = new RepoPedidos();
                repo.ModificarEstado(CadyPed.IdPedido, CadyPed.Estado);
                return Redirect("/Cadete/");
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
        public IActionResult AgregarPedido(int idPedido, int idCadete)
        {
            if (IsSesionIniciada() && (GetRol() == 0 || GetRol() == 1))
            {
                RepoPedidos repo = new RepoPedidos();
                repo.AgregarCadete(idPedido, idCadete);
                return Redirect("/Cadete/");
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
