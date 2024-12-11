﻿using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Interface
{
    public interface IPedidoService
    {
        public Task<ActionResult<List<PedidoListarDTO>>> GetAllPedidos();
        Task<string> CrearPedido(PedidoRequestDto pedido);
        public Task<List<PedidoListarDTO>> ListarPedidosPendientesPorEmpleado(int idEmpleado);
        public Task ActualizarEstadoPedido(int pedidoId);
        public Task CambiarEstadoEnPreparacion(string CodigoPedido, int empleadoId, DateTime tiempoPreparacion);
        public Task CambiarEstadoListoParaServir(string CodigoPedido, int empleadoId); // Nuevo método para cambiar a "listo para servir"
        public Task<string?> ObtenerTiempoDeDemora(int mesaId, string codigoComanda);
        public Task<List<PedidoListarDTO>> GetPedidosEnPreparacionConDemoras();
        public Task<ActionResult<string>> SiListoParaServirCambiarEstadoMesa(int mesaId);
        public Task<ActionResult<float>> CambiarEstadoMesaYCalcularTotal(string codigoComanda);
        public Task<string> CambiarEstadoMesaCerrada(string codigoComanda);
    }
}
