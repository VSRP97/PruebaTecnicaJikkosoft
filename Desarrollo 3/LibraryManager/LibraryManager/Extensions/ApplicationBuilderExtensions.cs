using LibraryManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using TemplateDbContext dbContext = scope.ServiceProvider.GetRequiredService<TemplateDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
