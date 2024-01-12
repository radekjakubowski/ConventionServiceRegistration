using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceThree))]
    public class ServiceThree
    {
        public string Message { get; init; }
    }
}
