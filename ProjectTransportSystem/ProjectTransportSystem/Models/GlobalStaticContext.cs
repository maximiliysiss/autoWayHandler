 using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models
{
    public class GlobalLogger
    {
        private readonly ILogger<GlobalLogger> _logger;

        public GlobalLogger(ILogger<GlobalLogger> logger)
        {
            _logger = logger;
        }

        public ILogger<GlobalLogger> Logger => _logger;
    }


    public class GlobalStaticContext
    {
        public static MainDbContext MainDbContext { get; set; } = new MainDbContext();

        private static GlobalLogger logger;

        public static ILogger<GlobalLogger> Logger
        {
            get
            {
                if (logger == null)
                    logger = new ServiceCollection()
                            .AddLogging(builder =>
                            {
                                builder.SetMinimumLevel(LogLevel.Trace);
                                builder.AddNLog(new NLogProviderOptions
                                {
                                    CaptureMessageTemplates = true,
                                    CaptureMessageProperties = true
                                });
                            })
                            .AddTransient<GlobalLogger>()
                            .BuildServiceProvider().GetRequiredService<GlobalLogger>();
                return logger.Logger;
            }
        }
    }
}
