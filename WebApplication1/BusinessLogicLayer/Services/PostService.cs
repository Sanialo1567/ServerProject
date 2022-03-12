using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Profiles;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PostProfile profile;
        private readonly INotificationService notificationService;

        public PostService(IUnitOfWork service)
        {
            _unitOfWork = service;
            profile = new(service);
            notificationService = new NotificationService(service);
        }

        public async Task<Guid> CreatePost(PostDtoModel postDto)
        {
            PostEntityModel postEM= profile.mapToEM(postDto);
            postEM = await _unitOfWork.Posts.CreateAsync(postEM);

            IEnumerable<SubscritptionEntityModel> subscriptions = await _unitOfWork.Subscriptions.FindByConditionAsync(sub => sub.WebPortalId == postEM.WebPortalId);

            foreach(var subscription in subscriptions)
            {
                NotificationEntityModel notification = new NotificationEntityModel
                {
                    Id = Guid.NewGuid(),
                    PostId = postEM.Id,
                    UserId = subscription.UserId,
                    Status = DbMigrations.EntityModels.Status.Unwatched,
                    WebPortalId = postEM.WebPortalId
                };
                await _unitOfWork.Notifications.CreateAsync(notification);
            }
            _unitOfWork.Save();

            return postEM.Id;
        }

        public async Task<IEnumerable<PostDtoModel>> GetAllPosts()
        {
            return profile.mapListToDto(await _unitOfWork.Posts.GetAllAsync());
        }

        public async Task<IEnumerable<PostDtoModel>> GetPostByCondition(Expression<Func<PostEntityModel, bool>> expression)
        {
            return profile.mapListToDto(await _unitOfWork.Posts.FindByConditionAsync(expression));
        }
    }
}
