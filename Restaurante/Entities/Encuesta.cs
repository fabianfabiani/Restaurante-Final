using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Encuesta : ClaseBase
    {
        public int MesaId { get; set; } // Clave foránea explícita para Mesa
        [ForeignKey(nameof(MesaId))]
        public Mesa Mesa { get; set; } // Relación con la entidad Mesa

        public int Puntuacion { get; set; } // Escala del 1 al 10
        public string Comentario { get; set; } // Texto opcional del cliente
    }
}


// El enunciado dice que las mesas tienen un codigo de identificador unico, pero en el diagrama de base de datos no aparece ese atributo