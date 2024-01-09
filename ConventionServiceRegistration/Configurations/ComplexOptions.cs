namespace ConventionServiceRegistration.Configurations
{
    public class ComplexOptions
    {
        public bool IsComplex { get; set; }
        public int LuckyNumber { get; set; }

        public override string ToString()
        {
            return $"Is complex: {IsComplex}, lucky number: {LuckyNumber}";
        }
    }
}
