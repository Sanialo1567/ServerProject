using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Profiles;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SubscriptionProfile profile;

        public SubscriptionService(IUnitOfWork service)
        {
            _unitOfWork = service;
            profile = new(service);
        }

        public async Task<Guid> CreateSubscription(SubscriptionDtoModel subscriptionDto)
        {
            SubscritptionEntityModel subscritptionEM = profile.mapToEM(subscriptionDto);
            subscritptionEM = await _unitOfWork.Subscriptions.CreateAsync(subscritptionEM);
            await _unitOfWork.SaveAsync();
            return subscritptionEM.Id;
        }

        public async Task<IEnumerable<SubscriptionDtoModel>> GetSubscriptionsByCondition(Expression<Func<SubscritptionEntityModel, bool>> expression)
        {
            return profile.mapListToDto(await _unitOfWork.Subscriptions.FindByConditionAsync(expression));
        }
    }
}
