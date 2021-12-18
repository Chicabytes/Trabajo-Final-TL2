using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Addon;
using tp6.ViewModel;

namespace tp6
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteViewModel>().ForMember
                (
                    dest => dest.IdCliente, origen => origen.MapFrom(src => src.Id)
                ).ReverseMap();
            CreateMap<PedidoViewModel, Cliente>();
            CreateMap<Pedido, Cliente>();
            CreateMap<PedidoViewModel, Pedido>().ForMember
                (
                    dest => dest.NCliente, origen =>origen.MapFrom(src => src.NCliente)
                );
            CreateMap<Pedido, PedidoViewModel>().ForMember
                (
                    dest => dest.NCliente, origen => origen.MapFrom(src => src.NCliente)
                );
            CreateMap<Pedido, AltaPedidoViewModel>().ReverseMap().ForMember
                (
                    dest => dest.Numpedido, origen => origen.MapFrom(src => src.NumeroDePedido)
                ).ForMember
                (
                    dest => dest.Obs, origen => origen.MapFrom(src => src.Observacion)
                ).ForMember
                (
                    dest => dest.Tipo, origen => origen.MapFrom(src => src.TPedido)
                );
            CreateMap<User, UserViewModel>().ForMember
                (
                    dest => dest.Id, origen => origen.MapFrom(src => src.Id)
                ).ReverseMap();
        }
    }
}
