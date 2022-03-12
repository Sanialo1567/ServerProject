using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Profiles;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private NotificationProfile profile;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new(unitOfWork);
        }

        public async Task<Guid> CreateNotification(NotificationDtoModel notificationDto)
        {
            NotificationEntityModel notificationEM = profile.mapToEM(notificationDto);
            notificationEM = await unitOfWork.Notifications.CreateAsync(notificationEM);

            return notificationEM.Id;
        }

        public async Task<IEnumerable<NotificationDtoModel>> GetAllNotificationsForUser(Guid userId)
        {
            IEnumerable<SubscritptionEntityModel> subscriptions = await unitOfWork.Subscriptions.FindByConditionAsync(s => s.UserId == userId);
            IList<WebPortalEntityModel> webPortals = new List<WebPortalEntityModel>();

            foreach(var subscription in subscriptions)
            {
                webPortals.Add(await unitOfWork.WebPortals.FindByIdAsync(subscription.WebPortalId));
            }

            IList<PostEntityModel> posts = new List<PostEntityModel>();

            foreach (var webPortal in webPortals)
            {
                IEnumerable<PostEntityModel> postss = await unitOfWork.Posts.FindByConditionAsync(p=>p.WebPortalId == webPortal.Id);
                foreach(var p in postss)
                {
                    posts.Add(p);
                }
            }

            IList<NotificationEntityModel> notifications = new List<NotificationEntityModel>();

            foreach(var post in posts)
            {
                IEnumerable<NotificationEntityModel> notifs = await unitOfWork.Notifications.FindByConditionAsync(n => n.PostId == post.Id && n.Status == DbMigrations.EntityModels.Status.Unwatched);
                foreach(var notif in notifs)
                {
                    notifications.Add(notif);
                }
            }

            return profile.mapListToDto(notifications);
        }

        public bool UpdateNotification(NotificationDtoModel notificationDto)
        {
            try
            {
                notificationDto.Status = DtoModels.Status.Watched;
                unitOfWork.Notifications.Update(profile.mapToEM(notificationDto));
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
