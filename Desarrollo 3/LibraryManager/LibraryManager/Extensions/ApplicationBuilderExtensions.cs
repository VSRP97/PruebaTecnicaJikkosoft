using LibraryManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using LibraryManagerDbContext dbContext = scope.ServiceProvider.GetRequiredService<LibraryManagerDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
