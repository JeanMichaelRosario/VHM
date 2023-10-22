using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Inyecta IConfiguration para acceder a la configuración de JWT
        private readonly IUserService _userService; // Inyecta tu servicio de usuario

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Valida las credenciales del usuario (esto dependerá de tu lógica)
            var user = _userService.ValidateUser(loginRequest.UserName, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(); // Usuario no válido
            }

            // Genera un token JWT
            var token = JwtUtils.GenerateJwtToken(user, _configuration);

            return Ok(new { Token = token });
        }
    }

}
