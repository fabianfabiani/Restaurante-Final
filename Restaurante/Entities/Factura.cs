using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Factura : ClaseBase
    {
        public int MesaId { get; set; } // Clave foránea explícita para Mesa
        [ForeignKey(nameof(MesaId))]
        public Mesa Mesa { get; set; } // Relación con la entidad Mesa

        public float Importe { get; set; } // Importe total de la factura
        public DateTime Fecha { get; set; } // Fecha de la factura
    }
}


// El enunciado dice que las mesas tienen un codigo de identificador unico, pero en el diagrama de base de datos no aparece ese atributo