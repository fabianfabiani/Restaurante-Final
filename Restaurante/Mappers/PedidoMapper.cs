using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class PedidoMapper : Profile
    {
        public PedidoMapper()
        {
            this.CreateMap<PedidoRequestDto, Pedido>().ReverseMap();
            CreateMap<Pedido, PedidoListarDTO>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto.Descripcion))
                .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Producto.Sector.descripcion))
                .ForMember(dest => dest.estadoPedido, opt => opt.MapFrom(src => src.EstadoPedido.Descripcion))
                .ForMember(dest => dest.nombreCliente, opt => opt.MapFrom(src => src.Comanda.nombreCliente)) // Nuevo mapeo para nombreCliente
                .ForMember(dest => dest.EstadoMesa, opt => opt.MapFrom(src => src.Comanda.Mesa.EstadoMesa.Descripcion)); // nuevo mostrar estado de mesa

            
            // Mapeo para PedidoFueraDeTiempo
            CreateMap<Pedido, PedidosFueraDeTiempoDto>()
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.FechaEstimadaDeFinalizacion, opt => opt.MapFrom(src => src.FechaEstimadaDeFinalizacion))
                .ForMember(dest => dest.FechaFinalizacion, opt => opt.MapFrom(src => src.FechaFinalizacion));
        }
    }
}
