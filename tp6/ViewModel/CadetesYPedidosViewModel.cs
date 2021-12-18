using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.ViewModel
{
    public class CadetesYPedidosViewModel
    {
        public List<Pedido> ListaPedidos { get; set; }
        public int IdCadete { get; set;}
        public int IdPedido { get; set; }
        public TipoPedido TipoPed { get; set; }
        public EstadoPedido Estado { get; set; }
    }
}
