using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Services;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceTwo))]
    public class ServiceTwoConfig
    {
        public string Message { get; init; }
    }
}
