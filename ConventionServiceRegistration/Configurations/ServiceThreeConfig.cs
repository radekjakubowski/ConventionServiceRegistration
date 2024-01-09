using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration]
    public class ServiceThreeConfig
    {
        public string Message { get; init; }
    }
}
