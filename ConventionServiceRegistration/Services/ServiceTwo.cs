using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Services.Interfaces;

namespace ConventionServiceRegistration.Services
{
    [LifetimeScope(InstanceLifetime.Singleton)]
    public class ServiceTwo : IServiceTwo
    {
        private readonly Guid creationId = Guid.NewGuid();

        public string GetMessage()
        {
            return $"Hello from service two - {creationId}";
        }
    }
}
