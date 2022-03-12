using System;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Services
{
    public interface IUnitOfWork : IDisposable
    {
        ICathegoryRepository Cathegories { get; }

        INotificationRepository Notifications { get; }

        IPostRepository Posts { get; }

        ISubscriptionRepository Subscriptions { get; }

        IUserRepository Users { get; }

        IWebPortalRepository WebPortals { get; }

        Task SaveAsync();

        public void Save();
    }
}
