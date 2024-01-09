namespace ConventionServiceRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SelfBindableConfigurationAttribute : Attribute
    {
        public string JsonKey { get; init; }

        public SelfBindableConfigurationAttribute(string jsonKey)
        {
            JsonKey = jsonKey;
        }
    }
}
