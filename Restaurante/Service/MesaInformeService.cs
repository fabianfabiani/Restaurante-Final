using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class MesaInformeService : IMesaInforme
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public MesaInformeService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<MesaListarDTO> MesaMasUsada()
        {
            var mesa = await _context.Mesas
                .OrderByDescending(m => m.Usos)
                .FirstOrDefaultAsync();

            if (mesa == null) throw new Exception("No se encontraron mesas.");

            return _mapper.Map<MesaListarDTO>(mesa);
        }


        public async Task<MesaListarDTO> MesaMenosUsada()
        {
            var mesa = await _context.Mesas
                .OrderBy(m => m.Usos)
                .FirstOrDefaultAsync();

            if (mesa == null) throw new Exception("No se encontraron mesas.");

            return _mapper.Map<MesaListarDTO>(mesa);
        }


        public async Task<MesaListarDTO> MesaMayorFacturacion()
        {
            var mesa = await _context.Mesas
                .OrderByDescending(m => m.TotalFacturado)
                .FirstOrDefaultAsync();

            if (mesa == null) throw new Exception("No se encontraron mesas.");

            return _mapper.Map<MesaListarDTO>(mesa);
        }

        public async Task<MesaListarDTO> MesaMenorFacturacion()
        {
            var mesa = await _context.Mesas
                .OrderBy(m => m.TotalFacturado)
                .FirstOrDefaultAsync();

            if (mesa == null) throw new Exception("No se encontraron mesas.");

            return _mapper.Map<MesaListarDTO>(mesa);
        }

        public async Task<MesaListarDTO> MesaMayorFactura()
        {
            var factura = await _context.Facturas
                .OrderByDescending(f => f.Importe)
                .FirstOrDefaultAsync();

            if (factura == null) throw new Exception("No se encontraron facturas.");

            var mesa = await _context.Mesas.FindAsync(factura.MesaId);
            return _mapper.Map<MesaListarDTO>(mesa);
        }


        public async Task<MesaListarDTO> MesaMenorFactura()
        {
            var factura = await _context.Facturas
                .OrderBy(f => f.Importe)
                .FirstOrDefaultAsync();

            if (factura == null) throw new Exception("No se encontraron facturas.");

            var mesa = await _context.Mesas.FindAsync(factura.MesaId);
            return _mapper.Map<MesaListarDTO>(mesa);
        }

    }
}

// Verificar si el EstadoMesaId existe en la base de datos
//Mesa? m = _context.Mesas.Where(m => m.EstadoMesaId == mesa.EstadoMesaId).FirstOrDefault();
/*Mesa? m = _context.Mesas.Where(m => m.Id == mesa.Id).FirstOrDefault();
if (m == null)
{
    throw new Exception("EstadoMesaId inexistente");
}*/