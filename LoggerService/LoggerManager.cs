using Application.Logging;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {
        }

        #region debug
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogDebug(Exception? exception, string message)
        {
            logger.Debug(exception, message);
        }
        #endregion

        #region error
        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogError(Exception? exception, string message)
        {
            logger.Error(exception, message);
        }
        #endregion

        #region info
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogInfo(Exception? exception, string message)
        {
            logger.Info(exception, message);
        }
        #endregion

        #region warn
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public void LogWarn(Exception? exception, string message)
        {
            logger.Warn(exception, message);
        }
        #endregion
    }
}
