namespace ConventionServiceRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LifetimeScopeAttribute : Attribute
    { 
        public InstanceLifetime InstanceLifetime { get; init; }

        public LifetimeScopeAttribute(InstanceLifetime instanceLifetime)
        {
            InstanceLifetime = instanceLifetime;
        }
    }
}
