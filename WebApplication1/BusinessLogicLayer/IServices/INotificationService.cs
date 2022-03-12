using BusinessLogicLayer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface INotificationService
    {
        Task<Guid> CreateNotification(NotificationDtoModel notificationDto);

        Task<IEnumerable<NotificationDtoModel>> GetAllNotificationsForUser(Guid userId);

        bool UpdateNotification (NotificationDtoModel notificationDto);
    }
}
