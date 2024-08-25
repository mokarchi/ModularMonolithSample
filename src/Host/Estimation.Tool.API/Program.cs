using System.Diagnostics.CodeAnalysis;
using Estimation.Tool.API;
using Estimation.Tool.API.Common.Configurations;
using Estimation.Tool.API.Common.Extensions;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                var envName = hostContext.HostingEnvironment.EnvironmentName;
                builder.AddAllConfigurationsFromSolution(envName);
                builder.AddEnvironmentVariables();
                if (hostContext.HostingEnvironment.IsForDevs())
                    builder.AddUserSecrets<Startup>();

                var configuration = builder.Build();
                //builder.AddApplicationConfiguration(configuration);
                builder.Build();
            })
        //.UseSharedInfrastructure()
        ;
}
