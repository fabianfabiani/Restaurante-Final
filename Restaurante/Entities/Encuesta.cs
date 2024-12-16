using Restaurante.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Encuesta : ClaseBase
    {

        public int PuntuacionMesa { get; set; }

        public int PuntuacionRestaurante { get; set; }

        public int PuntuacionMozo { get; set; }

        public int PuntuacionCocinero { get; set; }

        public string Comentario { get; set; }

        public DateTime FechaEncuesta { get; set; }

        public int ComandaId { get; set; } // Id de la Comanda, acepta null
        [ForeignKey(nameof(ComandaId))]
        public Comanda Comanda { get; set; } // Relación con la entidad Comanda


        //public int? MesaId { get; set; } // Id de la Mesa, acepta null

        //public Mesa Mesa { get; set; } // Relación con la entidad Mesa
    }
}