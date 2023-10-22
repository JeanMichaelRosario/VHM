// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Models
{
    public class RegistroDePlaca
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public DateTime BirthDate { get; set; }
        public char TipoDePlaca { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public TipoAutomovil TipoAutomovil { get; set; }
        public decimal Monto { get; set; }

        internal int GenerarPlaca()
        {
            Random random = new Random();

            // Genera 6 números aleatorios sin repeticiones
            int[] numerosAleatorios = Enumerable.Range(0, 10).OrderBy(x => random.Next()).Take(6).ToArray();

            string numeroAleatorioStr = string.Join("", numerosAleatorios);
            int numeroAleatorio = int.Parse(numeroAleatorioStr);

            return numeroAleatorio;
        }
    }
}
