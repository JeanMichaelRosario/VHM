namespace API.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public DateTime BirthDate { get; set; }
        public TipoPersona Tipo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public virtual IEnumerable<Placa> Placas { get; set;}
    }
}