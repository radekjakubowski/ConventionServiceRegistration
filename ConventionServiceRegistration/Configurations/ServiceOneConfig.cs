using ConventionServiceRegistration.Attributes;

namespace ConventionServiceRegistration.Configurations
{
    [SelfBindableConfiguration]
    public class ServiceOneConfig
    {
        public string Message { get; init; }
        public ComplexOptions Options { get; init; }
    }
}
