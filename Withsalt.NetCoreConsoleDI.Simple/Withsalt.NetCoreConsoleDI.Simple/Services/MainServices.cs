using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Withsalt.NetCoreConsoleDI.Simple.Services
{
    class MainServices
    {
        private readonly ILogger<MainServices> _logger;

        public MainServices(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<MainServices>();
        }

        public void Run()
        {
            Task.Run(() =>
            {
                //执行操作
                Console.WriteLine("111111111111");
                _logger.LogInformation("1111111111111");
            });
        }
    }
}
