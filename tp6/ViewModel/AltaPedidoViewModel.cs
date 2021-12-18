using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.ViewModel
{
    public class AltaPedidoViewModel
    {
        public int NumeroDePedido { get; set; }
        public TipoPedido TPedido { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Observacion { get; set; } 
    }
}
