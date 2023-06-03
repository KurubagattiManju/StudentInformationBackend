using StudentInfoApp.Services;
using Microsoft.AspNetCore.Mvc;
using StudentInfoApp.Models;

namespace StudentInfoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [Route("Login")]
        [HttpPost]

        public async Task<ActionResult<UserDTO>> Put([FromBody] UserDTO user)
        {
            var UserDTO = _service.Login(user);
            if (UserDTO != null)
                return Ok(UserDTO);
            return BadRequest("Not Working");

        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var UserDTO = _service.Register(user);
            if (UserDTO != null)
                return UserDTO;
            return BadRequest("Not able to Register");
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            if (_service.GetAll() != null)
            {
                return _service.GetAll();
            }
            return null;
        }
    }
}