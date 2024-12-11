using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Interface
{
    public interface IPedidoInformes
    {
        public Task<ProductoDTO> ObtenerProductoMasVendido();
        public Task<ProductoDTO> ObtenerProductoMenosVendido();
        public Task<List<PedidosFueraDeTiempoDto>> ObtenerPedidosFueraDeTiempo();
    }
}
