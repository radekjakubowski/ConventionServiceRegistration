using ConventionServiceRegistration.Attributes;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ConventionServiceRegistration.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void BindConfigurationsWithAttributes(this WebApplicationBuilder builder, string classPostfix = "Config")
        {
            builder.Services.AddOptions();

            var configClasses = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(_ => _.GetCustomAttributes().Any(_ => _ is SelfBindableConfigurationAttribute));

            foreach (var configClass in configClasses)
            {
                var configSectionName = configClass.Name.Split(classPostfix)[0]; // Get the name of the configuration class
                var settingsTypeInstance = Activator.CreateInstance(configClass);
                var optionsType = typeof(IOptions<>).MakeGenericType(configClass);

                builder.Configuration.GetSection(configSectionName).Bind(settingsTypeInstance);

                // Create an instance of Options<T> passing the settings instance to its constructor
                var optionsInstanceType = typeof(Options).GetMethod("Create").MakeGenericMethod(configClass);
                var optionsInstance = optionsInstanceType.Invoke(null, new object[] { settingsTypeInstance });

                builder.Services.AddSingleton(optionsType, optionsInstance);
            }
        }
    }
}
