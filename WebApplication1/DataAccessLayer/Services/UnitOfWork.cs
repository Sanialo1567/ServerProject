using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.Data;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        private ICathegoryRepository cathegories;
        private INotificationRepository notifications;
        private IPostRepository posts;
        private ISubscriptionRepository subscriptions;
        private IUserRepository users;
        private IWebPortalRepository webPortals;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public ICathegoryRepository Cathegories
        {
            get
            {
                if(cathegories == null)
                {
                    cathegories = new CathegoryRepository(context);
                }
                return cathegories;
            }
        }

        public INotificationRepository Notifications
        {
            get
            {
                if(notifications == null)
                {
                    notifications = new NotificationRepository(context);
                }
                return notifications;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                if(posts == null)
                {
                    posts = new PostRepository(context);
                }
                return posts;
            }
        }

        public ISubscriptionRepository Subscriptions 
        {
            get
            {
                if(subscriptions == null)
                {
                    subscriptions = new SubscriptionRepository(context);
                }
                return subscriptions;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if(users == null)
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        public IWebPortalRepository WebPortals
        {
            get
            {
                if(webPortals == null)
                {
                    webPortals = new WebPortalRepository(context);
                }
                return webPortals;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.DisposeAsync();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
