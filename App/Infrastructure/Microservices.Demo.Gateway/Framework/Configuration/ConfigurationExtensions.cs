using Microsoft.Extensions.Configuration;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Eureka;
using System;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Microservices.Demo.Gateway.Framework.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddOcelotConfiguration(this IServiceCollection services, IConfigurationManager configuration, IWebHostEnvironment environment)
        {
            var ocelotSection = configuration.GetSection("Routes");

            bool hasConfigServer = ocelotSection.GetChildren() != null && ocelotSection.GetChildren().Any();

            if (!hasConfigServer)
            {
                string configFolder = Path.Combine(environment.ContentRootPath, "ocelot-config");
                FileConfiguration mergedConfig = MergeOcelotConfigs(configFolder);

                configuration.SetBasePath(environment.ContentRootPath)
                    //.AddOcelot(mergedConfig, environment, MergeOcelotJson.ToMemory);
                    .AddOcelot("ocelot-config", environment, MergeOcelotJson.ToMemory);
                //.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            }

            services.AddOcelot(configuration)
                //.AddCacheManager(x => x.WithDictionaryHandle())
                .AddEureka();

            return services;
        }

        private static FileConfiguration MergeOcelotConfigs(string folder)
        {
                var regex = new Regex(@"^ocelot\..+\.json$", RegexOptions.IgnoreCase);
                var files = Directory.EnumerateFiles(folder, "*.json")
                    .Where(f => regex.IsMatch(Path.GetFileName(f)))
                    .ToArray();

                if (!files.Any(f => Path.GetFileName(f).Equals("ocelot.global.json", StringComparison.OrdinalIgnoreCase)))
                    throw new Exception("There must be at least one 'ocelot.global.json' file with the global configuration.");

                FileConfiguration merged = new FileConfiguration
                {
                    Routes = new List<FileRoute>(),
                    Aggregates = new List<FileAggregateRoute>()
                };

                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var cfg = JsonSerializer.Deserialize<FileConfiguration>(json);

                    if (cfg?.Routes != null && cfg.Routes.Count > 0)
                        merged.Routes.AddRange(cfg.Routes);

                    if (cfg?.Aggregates != null && cfg.Aggregates.Count > 0)
                        merged.Aggregates.AddRange(cfg.Aggregates);

                    // Only take the first valid global config
                    if (Path.GetFileName(file).Equals("ocelot.global.json", StringComparison.OrdinalIgnoreCase)
                        && cfg?.GlobalConfiguration != null)
                    {
                        merged.GlobalConfiguration = cfg.GlobalConfiguration;
                    }
                }

                if (merged.GlobalConfiguration == null)
                    throw new Exception("No valid GlobalConfiguration found.");
                if (merged.Routes.Count == 0)
                    Console.WriteLine("[WARN] No routes configured.");

            return merged;
        }
    }
}
