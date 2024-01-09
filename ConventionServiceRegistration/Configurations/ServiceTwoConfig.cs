using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration]
    public class ServiceTwoConfig
    {
        public string Message { get; init; }
    }
}
