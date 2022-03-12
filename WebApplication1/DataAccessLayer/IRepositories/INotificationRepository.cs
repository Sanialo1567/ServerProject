using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<NotificationEntityModel>> GetAllAsync();
        Task<IEnumerable<NotificationEntityModel>> FindByConditionAsync(Expression<Func<NotificationEntityModel, bool>> expression);
        Task<NotificationEntityModel> FindByIdAsync(Guid id);

        Task<NotificationEntityModel> CreateAsync(NotificationEntityModel item);

        void Update(NotificationEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<NotificationEntityModel> items);
    }
}
