using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Mappers;
using WebApplication1.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly PostMapper _mapper = new();

        public PostController(IPostService service)
        {
            postService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]PostViewModel postVM)
        {
            try
            {
                postVM.CreateDate = DateTime.UtcNow;
                PostDtoModel postDto = _mapper.mapToDto(postVM);

                return Ok(await postService.CreatePost(postDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
