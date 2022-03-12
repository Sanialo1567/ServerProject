using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDtoModel>> GetSubscriptionsByCondition(Expression<Func<SubscritptionEntityModel, bool>> expression);

        Task<Guid> CreateSubscription(SubscriptionDtoModel subscriptionDto);
    }
}
