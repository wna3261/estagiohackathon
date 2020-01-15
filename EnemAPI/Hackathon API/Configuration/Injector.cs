using Hackathon_API.Data;
using Hackathon_API.Data.Repositories;
using Hackathon_API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon_API.Configuration
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            // services
            services.AddScoped<ICandidatoService, CandidatoService>();

            // repositories
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
        }
    }
}