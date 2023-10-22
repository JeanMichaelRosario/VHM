using API.Db;
using API.Models;

namespace API.Helpers
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
    }

    public class UserValidation : IUserService
    {
        readonly ApiDbContext _dbContext;

        public UserValidation(ApiDbContext db)
        {
            _dbContext = db;
        }
        public User? ValidateUser(string username, string password)
        {
            var usuario = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (usuario != null && usuario.Password == password)
            {
                return usuario;
            }

            return null;
        }
    }
}