using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tp6.Models;
namespace tp6.ViewModel
{
    public class PedidoViewModel
    {
        public int IdPedido { get; set; }
        public TipoPedido TPedido { get; set; }
        public int IdCliente { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Observacion { get; set; }
        
        public Cliente NCliente { get; set; }
        public List<Pedido> ListadoDePedidos { get; set; }
        public List<CadeteViewModel> LCadetesVM { get; set; }
        public List<ClienteViewModel> LClientesVM { get; set; }
    }
}