using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Placa
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Monto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }
    }
}
