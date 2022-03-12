using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Mappers;
using BusinessLogicLayer.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserMapper _mapper = new UserMapper();

        public UserController(IUserService service)
        {
            userService = service;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(_mapper.mapListToVM(await userService.GetAllUsers()));
        }

        // POST api/<UserController>
        [HttpPost("/reader")]
        public async Task<IActionResult> CreateReader([FromBody]UserViewModel userViewModel)
        {
            try
            {
                IEnumerable<UserViewModel> usersVM = _mapper.mapListToVM(await userService.GetAllUsers());

                foreach (var user in usersVM)
                {
                    if (user.Mail == userViewModel.Mail)
                        return BadRequest();
                }

                userViewModel.Role = Role.Reader;
                Guid id = await userService.CreateUser(_mapper.mapToDto(userViewModel));
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
