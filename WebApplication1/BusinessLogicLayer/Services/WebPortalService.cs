using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Profiles;
using System.Linq.Expressions;
using DataAccessLayer.Services;

namespace BusinessLogicLayer.Services
{
    public class WebPortalService : IWebPortalService
    {
        private readonly IUnitOfWork unitOfWork;
        private WebPortalProfile profile;
        private INotificationService notificationService;

        public WebPortalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new(unitOfWork);
            notificationService = new NotificationService(unitOfWork);
        }        

        public async Task<Guid> CreateWebPortal(WebPortalDtoModel webPortalDto)
        {
            WebPortalEntityModel webPortalEM = profile.mapToEM(webPortalDto);
            webPortalEM.Cathegory = await unitOfWork.Cathegories.FindByIdAsync(webPortalEM.CathegoryId);
            webPortalEM = await unitOfWork.WebPortals.CreateAsync(webPortalEM);
            await unitOfWork.SaveAsync();
            return webPortalEM.Id;
        }

        public async Task<IEnumerable<WebPortalDtoModel>> GetAllWebPortals()
        {
            return profile.mapListToDto(await unitOfWork.WebPortals.GetAllAsync());
        }

        public async Task<IEnumerable<WebPortalDtoModel>> GetWebPortalByCondition(Expression<Func<WebPortalEntityModel, bool>> expression)
        {
            return profile.mapListToDto(await unitOfWork.WebPortals.FindByConditionAsync(expression));
        }

        public async Task<WebPortalDtoModel> GetWebPortalById(Guid id, Guid userId)
        {
            IEnumerable<NotificationEntityModel> notifications = await unitOfWork.Notifications.FindByConditionAsync(n => n.WebPortalId == id && n.UserId == userId);
            foreach(var notification in notifications)
            {
                notification.Status = DbMigrations.EntityModels.Status.Watched;
                unitOfWork.Notifications.Update(notification);
                unitOfWork.Save();
            }

            return profile.mapToDto(await unitOfWork.WebPortals.FindByIdAsync(id));
        }
    }
}
