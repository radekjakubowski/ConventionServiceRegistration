using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Configurations;
using ConventionServiceRegistration.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ConventionServiceRegistration.Services
{
    [LifetimeScope(InstanceLifetime.Transient)]
    public class ServiceOne : IServiceOne
    {
        private readonly Guid _creationId;
        private readonly IOptions<Configurations.ServiceOne> _options;

        public ServiceOne(IOptions<Configurations.ServiceOne> options)
        {
            _options = options;
            _creationId = Guid.NewGuid();
        }

        public string GetMessage()
        {
            return $"Hello from service one - {_creationId}. Message: {_options.Value.Message}. Complex object: {_options.Value.Options}";
        }
    }
}
