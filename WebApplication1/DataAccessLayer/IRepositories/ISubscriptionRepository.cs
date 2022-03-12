using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscritptionEntityModel>> GetAllAsync();
        Task<IEnumerable<SubscritptionEntityModel>> FindByConditionAsync(Expression<Func<SubscritptionEntityModel, bool>> expression);
        Task<SubscritptionEntityModel> FindByIdAsync(Guid id);

        Task<SubscritptionEntityModel> CreateAsync(SubscritptionEntityModel item);

        void Update(SubscritptionEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<SubscritptionEntityModel> items);
    }
}
