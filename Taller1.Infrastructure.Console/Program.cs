using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taller1.Infrastructure.Console.Runner;

namespace Taller1.Infrastructure.Console
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            IServiceCollection service = new ServiceCollection();
            service.AddSingleton(config);

            await new Entrypoint(config).Execute();
        }
    }
}