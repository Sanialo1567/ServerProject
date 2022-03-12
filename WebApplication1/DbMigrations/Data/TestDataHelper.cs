using Microsoft.EntityFrameworkCore;
using DbMigrations.EntityModels;
using System;
using System.Linq;

namespace DbMigrations.Data
{
    public class TestDataHelper
    {
        public static void InitTestData(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlite($"Data Source=db").Options;

            using (AppDbContext db = new AppDbContext(options))
            {
                db.Database.EnsureCreated();
                Guid cathegoryId1 = Guid.NewGuid();
                Guid cathegoryId2 = Guid.NewGuid();

                if (!db.Cathegories.Any())
                {
                    db.Cathegories.Add(new CathegoryEntityModel
                    {
                        Id = cathegoryId1,
                        Name = "Sport",
                        Description = "asdasd",
                    });

                    db.Cathegories.Add(new CathegoryEntityModel
                    {
                        Id = cathegoryId2,
                        Name = "Food",
                        Description = "orange",
                    });
                }
                db.SaveChanges();

                Guid userId1 = Guid.NewGuid();
                Guid userId2 = Guid.NewGuid();
                Guid userId3 = Guid.NewGuid();

                if (!db.Users.Any())
                {
                    db.Users.Add(new UserEntityModel
                    {
                        Id = userId1,
                        Name = "Sasha",
                        Surname = "Sever",
                        Mail = "sever@gmail.com",
                        Password = "sever123456",
                        Role = Role.Reader
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = userId2,
                        Name = "Danik",
                        Surname = "Finskiy",
                        Mail = "fin@gmail.com",
                        Password = "fin123456",
                        Role = Role.Owner
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = userId3,
                        Name = "Nikita",
                        Surname = "Zaycev",
                        Mail = "zaycev@gmail.com",
                        Password = "zaycev123456",
                        Role = Role.Admin
                    });
                }
                db.SaveChanges();


                Guid webPortalId1 = Guid.NewGuid();
                Guid webPortalId2 = Guid.NewGuid();

                if (!db.WebPortals.Any())
                {
                    db.WebPortals.Add(new WebPortalEntityModel
                    {
                        Id = webPortalId1,
                        Name = "Sport24/7",
                        Description = "All about sport",
                        OwnerId = userId2,
                        CathegoryId = cathegoryId1
                    });

                    db.WebPortals.Add(new WebPortalEntityModel
                    {
                        Id = webPortalId2,
                        Name = "LoveFoodEveryDay",
                        Description = "100 recepies of your happy day",
                        OwnerId = userId2,
                        CathegoryId = cathegoryId2
                    });
                }
                db.SaveChanges();

                Guid postId1 = Guid.NewGuid();
                Guid postId2 = Guid.NewGuid();

                if (!db.Posts.Any())
                {
                    db.Posts.Add(new PostEntityModel
                    {
                        Id = postId1,
                        Name = "First Post",
                        Text = "I'm just testing this",
                        CreateDate = DateTime.UtcNow,
                        WebPortalId = webPortalId1
                    });

                    db.Posts.Add(new PostEntityModel
                    {
                        Id = postId2,
                        Name = "Second Post",
                        Text = "I'm just testing this 2nd time",
                        CreateDate = DateTime.UtcNow,
                        WebPortalId = webPortalId1
                    });
                }
                db.SaveChanges();

                Guid subscriptionId1 = Guid.NewGuid();
                Guid subscriptionId2 = Guid.NewGuid();

                if (!db.Subscritptions.Any())
                {
                    db.Subscritptions.Add(new SubscritptionEntityModel
                    {
                        Id = subscriptionId1,
                        UserId = userId1,
                        WebPortalId = webPortalId1
                    });

                    db.Subscritptions.Add(new SubscritptionEntityModel
                    {
                        Id = subscriptionId2,
                        UserId = userId2,
                        WebPortalId = webPortalId1
                    });
                }
                db.SaveChanges();

                Guid notificationId1 = Guid.NewGuid();
                Guid notificationId2 = Guid.NewGuid();

                if (!db.Notifications.Any())
                {
                    db.Notifications.Add(new NotificationEntityModel
                    {
                        Id = notificationId1,
                        UserId = userId1,
                        PostId = postId1,
                        WebPortalId = webPortalId1,
                        Status = Status.Unwatched
                    });

                    db.Notifications.Add(new NotificationEntityModel
                    {
                        Id = notificationId2,
                        UserId = userId1,
                        PostId = postId2,
                        WebPortalId = webPortalId1,
                        Status = Status.Unwatched
                    });
                }
                db.SaveChanges();
            }
        }
    }
}
