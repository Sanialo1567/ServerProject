using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Mappers;
using BusinessLogicLayer.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BusinessLogicLayer.DtoModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/webPortals")]
    [ApiController]
    public class WebPortalController : ControllerBase
    {

        private readonly IWebPortalService webPortalService;
        private readonly ISubscriptionService subscriptionService;
        private readonly IUserService userService;
        private readonly ICathegoryService cathegoryService;
        private readonly IPostService postService;
        private readonly WebPortalMapper _mapper = new();
        private readonly CathegoryMapper mapperCathegory = new();
        private readonly UserMapper mapperUser = new();
        private readonly PostMapper mapperPost = new();

        public WebPortalController(IWebPortalService service, ISubscriptionService subscriptionService, IUserService userService, ICathegoryService cathegoryService, IPostService postService)
        {
            webPortalService = service;
            this.subscriptionService = subscriptionService;
            this.userService = userService;
            this.cathegoryService=cathegoryService;
            this.postService = postService;
        }

        // GET: api/<WebPortalController>
        [HttpGet]
        public async Task<IActionResult> GetAllWebPortals()
        {
            try
            {
                IEnumerable<WebPortalViewModel> webPortals = _mapper.mapListToVM(await webPortalService.GetAllWebPortals());

                foreach (var webPortalVM in webPortals)
                {

                    IEnumerable<SubscriptionDtoModel> subList = await subscriptionService.GetSubscriptionsByCondition(s => s.WebPortalId == webPortalVM.Id);
                    IList<UserViewModel> users = new List<UserViewModel>();

                    foreach (var subscription in subList)
                    {
                        UserViewModel user = mapperUser.mapToVM(await userService.GetUserById(subscription.UserId));
                        users.Add(user);
                    }

                    webPortalVM.Users = users;

                    IEnumerable<PostViewModel> postList = mapperPost.mapListToVM(await postService.GetPostByCondition(s => s.WebPortalId == webPortalVM.Id));

                    webPortalVM.Posts = (IList<PostViewModel>)postList;
                }

                return Ok(webPortals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       


        [HttpGet("/list/{filter}")]
        public async Task<IActionResult> GetWebPortalsByConditions(string filter)
        {
            try
            {
                IEnumerable<WebPortalViewModel> webPortalsVM = _mapper.mapListToVM(await webPortalService.GetWebPortalByCondition(s => s.Name == filter || s.Description == filter));

                return Ok(webPortalsVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/{userId}")]
        public async Task<IActionResult> GetWebPortalsById(Guid id, Guid userId)
        {
            try
            {
                WebPortalViewModel webPortalVM = _mapper.mapToVM(await webPortalService.GetWebPortalById(id, userId));

                IEnumerable<SubscriptionDtoModel> subList = await subscriptionService.GetSubscriptionsByCondition(s => s.WebPortalId == id);
                IList<UserViewModel> users = new List<UserViewModel>();

                foreach (var subscription in subList)
                {
                    UserViewModel user = mapperUser.mapToVM(await userService.GetUserById(subscription.UserId));
                    users.Add(user);
                }

                webPortalVM.Users = users;

                IEnumerable<PostViewModel> postList = mapperPost.mapListToVM(await postService.GetPostByCondition(s => s.WebPortalId == id));

                webPortalVM.Posts = (IList<PostViewModel>)postList;

                return Ok(webPortalVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cathegory/{cathegoryId}")]
        public async Task<IActionResult> GetWebPortalsBycathegoryId(Guid cathegoryId)
        {
            try
            {
                IEnumerable<WebPortalViewModel> webPortalsVM = _mapper.mapListToVM(await webPortalService.GetWebPortalByCondition(wb => wb.CathegoryId == cathegoryId));

                return Ok(webPortalsVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<WebPortalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WebPortalViewModel webPortalVM)
        {
            try
            {
                if (webPortalVM == null)
                {
                    return BadRequest();
                }

                UserDtoModel user = await userService.GetUserById(webPortalVM.OwnerId);

                user.Role = BusinessLogicLayer.DtoModels.Role.Owner;

                await userService.UpdateUser(user);

                WebPortalDtoModel webPortalDto = _mapper.mapToDto(webPortalVM);

                webPortalDto.Id = await webPortalService.CreateWebPortal(webPortalDto);

                return Ok(webPortalDto.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
