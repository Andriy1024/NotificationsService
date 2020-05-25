using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NotificationService.Application;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Handlers.Orders;
using NotificationService.Persistence;
using System.Reflection;

namespace NotificationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification Service API", Version = "v1" });
            });

            services
              .AddFluentEmail(defaultFromEmail: "shop@shop.com", defaultFromName: "Shop")
              .AddSendGridSender("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");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=NotificationService;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(GetProductsQuery).Assembly, typeof(GetProductsQueryHandler).Assembly);
            services.AddAutoMapper(typeof(OrderMapper));

            services
                .AddMvc()
                .AddFluentValidation(t => t.RegisterValidatorsFromAssemblyContaining<CreateOrderCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification Service API");
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
