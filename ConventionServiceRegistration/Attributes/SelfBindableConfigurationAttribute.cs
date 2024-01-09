namespace ConventionServiceRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SelfBindableConfigurationAttribute : Attribute
    {
    }
}
