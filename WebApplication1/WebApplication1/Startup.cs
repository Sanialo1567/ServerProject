using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DbMigrations.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Services;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source=db"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            services.AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWebPortalService, WebPortalService>();
            services.AddScoped<ICathegoryService, CathegoryService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            TestDataHelper.InitTestData(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
