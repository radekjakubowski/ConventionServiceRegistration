using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration(jsonKey: nameof(ServiceOne))]
    public class ServiceOne
    {
        public string Message { get; init; }
        public ComplexOptions Options { get; init; }
    }
}
