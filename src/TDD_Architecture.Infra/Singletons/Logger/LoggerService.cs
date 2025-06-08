using Microsoft.Extensions.Logging;
using TDD_Architecture.Infra.Singletons.Logger.Interfaces;

namespace TDD_Architecture.Infra.Singletons.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation($"[INFO] {DateTime.UtcNow}: {message}");
        }

        public void LogError(string message)
        {
            _logger.LogError($"[ERROR] {DateTime.UtcNow}: {message}");
        }
    }
}
