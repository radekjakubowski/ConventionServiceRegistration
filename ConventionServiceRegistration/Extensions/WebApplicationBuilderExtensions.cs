using ConventionServiceRegistration.Attributes;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ConventionServiceRegistration.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void BindConfigurationsWithAttributes(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions();

            var configClasses = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(IsMarkedAsSelfBindableConfiguration);

            foreach (var configClass in configClasses)
            {
                var configSectionName = configClass.GetCustomAttribute<SelfBindableConfigurationAttribute>()!.JsonKey;
                var settingsTypeInstance = Activator.CreateInstance(configClass);
                var optionsType = typeof(IOptions<>).MakeGenericType(configClass);

                var configSection = builder.Configuration.GetSection(configSectionName);
                configSection.Bind(settingsTypeInstance);

                // Create an instance of Options<T> passing the settings instance to its constructor
                var optionsInstanceType = typeof(Options).GetMethod("Create")?.MakeGenericMethod(configClass);
                var optionsInstance = optionsInstanceType?.Invoke(null, new object[] { settingsTypeInstance! });

                builder.Services.AddSingleton(optionsType, optionsInstance!);
            }

            static bool IsMarkedAsSelfBindableConfiguration(Type configType)
            {
                return configType.GetCustomAttributes().Any(_ => _ is SelfBindableConfigurationAttribute);
            }
        }
    }
}
