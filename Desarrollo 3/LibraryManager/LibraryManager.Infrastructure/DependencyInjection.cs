using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LibraryManager.Application.Abstractions.Caching;
using LibraryManager.Application.Abstractions.Clock;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Users;
using LibraryManager.Infrastructure.Caching;
using LibraryManager.Infrastructure.Clock;
using LibraryManager.Infrastructure.Data;
using LibraryManager.Infrastructure.Repositories;
using LibraryManager.Infrastructure.TypesHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);

            AddCaching(services);

            AddCustomRepositories(services);

            AddCustomServices(services);

            AddHealthChecks(services, configuration);

            AddTypesHandler();

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

            // Replace the incorrect method 'UsqSqlServer' with the correct method 'UseSqlServer'
            services.AddDbContext<TemplateDbContext>(options =>
            {
                options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TemplateDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        }

        private static void AddCaching(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<ICacheService, CacheService>();
        }

        private static void AddCustomServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }

        private static void AddCustomRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Database")!);
        }

        public static void AddTypesHandler()
        {
            //SqlMapper.AddTypeHandler(new EnumTypeHandler<T>();
        }
    }
}
