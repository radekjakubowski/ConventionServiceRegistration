using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Configurations;
using ConventionServiceRegistration.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ConventionServiceRegistration.Services
{
    [LifetimeScope(InstanceLifetime.Singleton)]
    public class ServiceTwo : IServiceTwo
    {
        private readonly Guid _creationId;
        private readonly IOptions<Configurations.ServiceTwo> _options;

        public ServiceTwo(IOptions<Configurations.ServiceTwo> options)
        {
            _options = options;
            _creationId = Guid.NewGuid();
        }

        public string GetMessage()
        {
            return $"Hello from service two - {_creationId}. Message: {_options.Value.Message}";
        }
    }
}
