using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Services.Interfaces;

namespace ConventionServiceRegistration.Services
{
    [LifetimeScope(InstanceLifetime.Transient)]
    public class ServiceOne : IServiceOne
    {
        private readonly Guid creationId = Guid.NewGuid();

        public string GetMessage()
        {
            return $"Hello from service one - {creationId}";
        }
    }
}
