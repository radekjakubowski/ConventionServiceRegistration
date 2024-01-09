using ConventionServiceRegistration.Attributes;
using ConventionServiceRegistration.Services;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceThree))]
    public class ServiceThreeConfig
    {
        public string Message { get; init; }
    }
}
