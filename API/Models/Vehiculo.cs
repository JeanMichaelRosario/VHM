using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public TipoAutomovil Tipo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}