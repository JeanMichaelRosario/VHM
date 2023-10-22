// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Models
{
    public class ConsultaDePlaca
    {
        public Propietario Cliente { get; set; }
        public List<InformacionPlaca> Placas { get; set; }
    }
}
