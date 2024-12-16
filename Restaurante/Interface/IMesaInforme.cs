using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Interface
{
    public interface IMesaInforme
    {
        public Task<MesaListarDTO> MesaMasUsada();
        public Task<MesaListarDTO> MesaMenosUsada();
        public Task<MesaListarDTO> MesaMayorFacturacion();

        public Task<MesaListarDTO> MesaMenorFacturacion();

        public Task<MesaListarDTO> MesaMayorFactura();

        public Task<MesaListarDTO> MesaMenorFactura();

    }
}
