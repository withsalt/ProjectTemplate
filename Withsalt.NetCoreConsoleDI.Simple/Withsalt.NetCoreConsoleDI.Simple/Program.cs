using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Withsalt.NetCoreConsoleDI.Simple.Services;

namespace Withsalt.NetCoreConsoleDI.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Startup startup = new Startup(configuration);
            startup.ConfigureServices();
            var provider= startup.Services.BuildServiceProvider();

            
            var mainServices = provider.GetService<MainServices>();
            mainServices.Run();

            while (true)
            {
                Console.ReadKey(true);
            }
        }
    }
}
