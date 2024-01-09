using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Configurations;
using ConventionServiceRegistration.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ConventionServiceRegistration.Services
{
    [LifetimeScope(InstanceLifetime.Transient)]
    public class ServiceThree : IServiceThree
    {
        private readonly Guid _creationId;
        private readonly IOptions<ServiceThreeConfig> _options;

        public ServiceThree(IOptions<ServiceThreeConfig> options)
        {
            _options = options;
            _creationId = Guid.NewGuid();
        }

        public string GetMessage()
        {
            return $"Hello from service three - {_creationId}. Message: {_options.Value.Message}";
        }
    }
}
