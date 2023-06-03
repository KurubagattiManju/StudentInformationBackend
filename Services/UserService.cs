using StudentInfoApp.Data;
using StudentInfoApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace StudentInfoApp.Services
{
    public class UserService
    {
        private readonly StudentDbContext context;
        private readonly ITokenService _tokenService;
        public UserService(StudentDbContext _context, ITokenService tokenService)
        {
            context = _context;
            _tokenService = tokenService;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            try
            {
                var myUser = context.User.SingleOrDefault(c => c.Email_Id == userDTO.Email_Id);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDTO.jwtToken = _tokenService.CreateToken(userDTO);
                    userDTO.Password = "";
                    return userDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public UserDTO Register(UserDTO userDTO)
        {

            try
            {
                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    UserIdnew = userDTO.UserIdnew,
                    Email_Id = userDTO.Email_Id,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                    PasswordSalt = hmac.Key,

                };

                context.User.Add(user);
                context.SaveChanges();
                userDTO.jwtToken = _tokenService.CreateToken(userDTO);
                userDTO.Password = "";



                return userDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<User> GetAll()
        {
            List<User> users = context.User.ToList();
            return users;
        }
    }
}