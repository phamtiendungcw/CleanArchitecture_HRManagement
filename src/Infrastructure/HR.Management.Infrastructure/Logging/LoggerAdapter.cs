using HR.Management.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace HR.Management.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWaring(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}