using Microsoft.Extensions.DependencyInjection;
using ProvaAdmissionalCSharpApisul.Service;

namespace ProvaAdmissionalCSharpApisul.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IElevadorService, ElevadorService>();


            return services;

        }

    }
}
