using Microsoft.Extensions.Logging;

namespace Project0.DataAccess
{
    /// <summary>
    /// Contains the logger factory for logging the SQL ORM.
    /// </summary>
    internal class SQLLogger
    {
        public static readonly ILoggerFactory AppLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddConsole();
        });
    }
}
