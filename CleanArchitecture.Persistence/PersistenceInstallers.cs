using CleanArchitecture.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceInstallers
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
        }
    }
}
