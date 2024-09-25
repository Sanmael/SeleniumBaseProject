using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EstudandoAutomacao
{
    public static class ConfigurationManager
    {
        private static IConfiguration? configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    var appSettingsPath = Path.Combine(assemblyPath!, "appsettings.json");

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(assemblyPath)
                        .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true);

                    configuration = builder.Build();
                }

                return configuration;
            }
        }
    }
}
