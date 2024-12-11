using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class ProductoMapper : Profile
    {
        public ProductoMapper()
        {
            // Mapeo para Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.CantidadVendida, opt => opt.Ignore());
        }
    }
}
