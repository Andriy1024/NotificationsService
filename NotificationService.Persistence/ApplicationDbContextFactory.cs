using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace NotificationService.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> 
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=NotificationService;Trusted_Connection=True;MultipleActiveResultSets=true");

            return Activator.CreateInstance(typeof(ApplicationDbContext), optionsBuilder.Options) as ApplicationDbContext;
        }
    }
}
