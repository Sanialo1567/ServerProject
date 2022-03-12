using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubscriptionDtoModel subscriptionDto)
        {
            try
            {
                if (subscriptionDto == null)
                    return BadRequest();

                Guid checkid = await subscriptionService.CreateSubscription(subscriptionDto);

                return Ok(checkid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
