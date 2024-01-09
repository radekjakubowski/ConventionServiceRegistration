using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Services;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceOne))]
    public class ServiceOneConfig
    {
        public string Message { get; init; }
        public ComplexOptions Options { get; init; }
    }
}
