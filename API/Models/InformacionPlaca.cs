// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Models
{
    public class InformacionPlaca
    {
        public char TipoDePlaca { get; set; }
        public string NumeroDePlaca { get; set; }
        public DateTime FechaDeVenta { get; set; }
        public decimal Monto { get; set; }
    }
}
