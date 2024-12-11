using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class PedidoInformes : IPedidoInformes
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public PedidoInformes(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductoDTO> ObtenerProductoMasVendido()
        {
            var producto = await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderByDescending(g => g.Sum(p => p.Cantidad))
                .Select(g => new { Producto = g.FirstOrDefault().Producto, CantidadVendida = g.Sum(p => p.Cantidad) })
                .FirstOrDefaultAsync();

            if (producto == null) return null;

            var productoDTO = _mapper.Map<ProductoDTO>(producto.Producto);
            productoDTO.CantidadVendida = producto.CantidadVendida;
            return productoDTO;
        }

        public async Task<ProductoDTO> ObtenerProductoMenosVendido()
        {
            var producto = await _context.Pedidos
                .GroupBy(p => p.ProductoId)
                .OrderBy(g => g.Sum(p => p.Cantidad))
                .Select(g => g.FirstOrDefault().Producto)
                .FirstOrDefaultAsync();

            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<List<PedidosFueraDeTiempoDto>> ObtenerPedidosFueraDeTiempo()
        {
            var pedidos = await _context.Pedidos
                .Where(p => p.FechaFinalizacion > p.FechaEstimadaDeFinalizacion)
                .ToListAsync();

            return _mapper.Map<List<PedidosFueraDeTiempoDto>>(pedidos);
        }
    }
}
