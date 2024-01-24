using System.Net.Security;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCRUDApplication.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IUserServices _userServices;
       public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            UserValidation validator = new UserValidation();
            var validationResult = validator.Validate(userDTO);
            if (validationResult.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userServices.CreateUserAsync(userDTO.name, userDTO.email, userDTO.gender, userDTO.age);
            if(user == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userServices.GetUserAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userServices.GetAllUsersAsync()); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserDTO userDTO)
        {
            UserValidation validator = new UserValidation();
            var validatorResult = validator.Validate(userDTO);
            if (validatorResult.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateUser = await _userServices.UpdateUserAsync(id, userDTO.name, userDTO.email, userDTO.gender, userDTO.age);
            if(updateUser == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(updateUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userServices.DeleteUserAsync(id);
            return result ? Ok(true) : Ok(false);
        }
    }
}
