using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WriteTheRest.Core.Attributes;

namespace WriteTheRest.Core.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddScopedServicesFromAssemblies(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                var interfaces = types
                    .Where(t => t.IsInterface && t.Name.StartsWith("I"))
                    .ToList();

                var implementations = types
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .ToList();

                foreach (var iface in interfaces)
                {
                    var preferredImpl = implementations
                        .Where(c => iface.IsAssignableFrom(c))
                        .Where(c => c.GetCustomAttribute<PreferredImplementationAttribute>()?.IsActive == true)
                        .FirstOrDefault();

                    if (preferredImpl != null)
                    {
                        services.AddScoped(iface, preferredImpl);
                    }
                }
            }

            return services;
        }
    }
}
