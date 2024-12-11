namespace Restaurante.Dto
{
    public class PedidosFueraDeTiempoDto
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEstimadaDeFinalizacion { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }

}
