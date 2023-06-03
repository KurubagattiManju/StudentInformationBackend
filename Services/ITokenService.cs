using StudentInfoApp.Models;

namespace StudentInfoApp.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}