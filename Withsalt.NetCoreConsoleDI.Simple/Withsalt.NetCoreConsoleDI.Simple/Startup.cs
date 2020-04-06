using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Withsalt.NetCoreConsoleDI.Simple.Services;

namespace Withsalt.NetCoreConsoleDI.Simple
{
    class Startup
    {
        public IConfiguration Configuration { get; }

        public IServiceCollection Services { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.Services = new ServiceCollection();
            this.Configuration = configuration;
        }

        public void ConfigureServices()
        {
            //日志，可以自由选择日志组件，这里使用Nlog
            Services.AddLogging((builder) =>
            {
                builder.ClearProviders();
                builder.AddNLog();
            });

            Services.AddScoped<MainServices>();
        }
    }
}
