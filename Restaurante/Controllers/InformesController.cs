using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformesController : Controller
    {
        private readonly IPedidoInformes _pedidoInformes;

        public InformesController(IPedidoInformes pedidoInformes)
        {
            _pedidoInformes = pedidoInformes;
        }

        [HttpGet("GetProductoMasVendido")]
        public async Task<IActionResult> ObtenerProductoMasVendido()
        {
            var producto = await _pedidoInformes.ObtenerProductoMasVendido();
            return Ok(producto);
        }

        [HttpGet("GetProductoMenosVendido")]
        public async Task<IActionResult> ObtenerProductoMenosVendido()
        {
            var producto = await _pedidoInformes.ObtenerProductoMenosVendido();
            return Ok(producto);
        }

        [HttpGet("GetPedidoFueraDeTiempo")]
        public async Task<IActionResult> ObtenerPedidosFueraDeTiempo()
        {
            var pedidos = await _pedidoInformes.ObtenerPedidosFueraDeTiempo();
            return Ok(pedidos);
        }
    }
}




