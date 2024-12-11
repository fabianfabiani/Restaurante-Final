using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeMesaController : Controller
    {
        private readonly IMesaInforme _mesaInformeService;

        public InformeMesaController(IMesaInforme mesaInformeService)
        {
            _mesaInformeService = mesaInformeService;
        }

        // Endpoint para obtener la mesa menos usada
        [HttpGet("getMesaMenosUsada")]
        public async Task<ActionResult<MesaListarDTO>> MesaMenosUsada()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMenosUsada();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa menos usada", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener la mesa más usada
        [HttpGet("getMesaMasUsada")]
        public async Task<ActionResult<MesaListarDTO>> MesaMasUsada()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMasUsada();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa más usada", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener la mesa con mayor facturación
        [HttpGet("getMesaMayorFacturacion")]
        public async Task<ActionResult<MesaListarDTO>> MesaMayorFacturacion()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMayorFacturacion();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa con mayor facturación", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener la mesa con menor facturación
        [HttpGet("getMesaMenorFacturacion")]
        public async Task<ActionResult<MesaListarDTO>> MesaMenorFacturacion()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMenorFacturacion();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa con menor facturación", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener la mesa con la factura de mayor importe
        [HttpGet("getMesaMayorFactura")]
        public async Task<ActionResult<MesaListarDTO>> MesaMayorFactura()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMayorFactura();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa con la factura de mayor importe", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener la mesa con la factura de menor importe
        [HttpGet("getMesaMenorFactura")]
        public async Task<ActionResult<MesaListarDTO>> MesaMenorFactura()
        {
            var mesaResponseDto = await _mesaInformeService.MesaMenorFactura();
            if (mesaResponseDto == null)
            {
                return NotFound("No se encontraron mesas.");
            }

            return Ok(new { Message = "Mesa con la factura de menor importe", Mesa = mesaResponseDto });
        }

        // Endpoint para obtener las mesas con mejores comentarios (por puntuación)
        [HttpGet("getMesaMejoresComentarios")]
        public async Task<ActionResult<List<MesaListarDTO>>> MesaMejoresComentarios()
        {
            var mesasResponseDto = await _mesaInformeService.MesaMejoresComentarios();
            if (mesasResponseDto == null || !mesasResponseDto.Any())
            {
                return NotFound("No se encontraron mesas con buenos comentarios.");
            }

            return Ok(new { Message = "Mesas con mejores comentarios", Mesas = mesasResponseDto });
        }

        // Endpoint para obtener las mesas con peores comentarios (por puntuación)
        [HttpGet("getMesaPeoresComentarios")]
        public async Task<ActionResult<List<MesaListarDTO>>> MesaPeoresComentarios()
        {
            var mesasResponseDto = await _mesaInformeService.MesaPeoresComentarios();
            if (mesasResponseDto == null || !mesasResponseDto.Any())
            {
                return NotFound("No se encontraron mesas con malos comentarios.");
            }

            return Ok(new { Message = "Mesas con peores comentarios", Mesas = mesasResponseDto });
        }
    }
}
