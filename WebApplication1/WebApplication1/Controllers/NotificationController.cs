using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        private readonly NotificationMapper _mapper = new();

        public NotificationController(INotificationService service)
        {
            notificationService = service;
        }

        // GET api/<NotificationController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllNotificationsForUser(Guid userId)
        {
            try
            {
                IEnumerable<NotificationDtoModel> notificationsDto = await notificationService.GetAllNotificationsForUser(userId);
                return Ok(_mapper.mapListToVM(notificationsDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
