namespace ConventionServiceRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class LifetimeScopeAttribute : Attribute
    { 
        public InstanceLifetime InstanceLifetime { get; init; }

        public LifetimeScopeAttribute(InstanceLifetime instanceLifetime)
        {
            InstanceLifetime = instanceLifetime;
        }
    }
}
