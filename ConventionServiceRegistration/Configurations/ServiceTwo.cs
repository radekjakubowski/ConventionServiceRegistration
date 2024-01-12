using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceTwo))]
    public class ServiceTwo
    {
        public string Message { get; init; }
    }
}
