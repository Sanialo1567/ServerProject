using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CathegoryEntityModel> Cathegories{ get; set; }

        public DbSet<NotificationEntityModel> Notifications { get; set; }
        
        public DbSet<PostEntityModel> Posts { get; set; }

        public DbSet<SubscritptionEntityModel> Subscritptions { get; set; }

        public DbSet<UserEntityModel> Users { get; set; }

        public DbSet<WebPortalEntityModel> WebPortals { get; set; }
    }
}
