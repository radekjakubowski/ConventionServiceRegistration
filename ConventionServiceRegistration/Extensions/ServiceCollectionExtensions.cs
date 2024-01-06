using ConventionServiceRegistration.Attributes;
using System.Reflection;

namespace ConventionServiceRegistration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServicesWithAttributes(this IServiceCollection services)
        {
            var servicesWithScopes = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(IsMarkedWithLifetimeInstanceAndImplementsRegularInterface)
                                    .Select(type => (type, interfaceType: type.GetInterface($"I{type.Name}"), scope: type.GetCustomAttribute<LifetimeScopeAttribute>()!.InstanceLifetime));

            foreach (var registration in servicesWithScopes)
            {
                var serviceDescriptor = registration.scope switch
                {
                    InstanceLifetime.Singleton => ServiceDescriptor.Singleton(registration.interfaceType!, registration.type),
                    InstanceLifetime.Scoped => ServiceDescriptor.Scoped(registration.interfaceType!, registration.type),
                    InstanceLifetime.Transient => ServiceDescriptor.Transient(registration.interfaceType!, registration.type),
                    _ => throw new NotSupportedException("Scope not supported")
                };

                services.Add(serviceDescriptor);
            }
        }

        private static bool IsMarkedWithLifetimeInstanceAndImplementsRegularInterface(Type type)
        {
            return type.GetCustomAttributes().Any(attr => attr is LifetimeScopeAttribute) && type.GetInterface($"I{type.Name}") is not null;
        }
    }
}
