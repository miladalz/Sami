using System;

namespace Application.Logging
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogInfo(Exception? exception, string message);

        void LogWarn(string message);
        void LogWarn(Exception? exception, string message);

        void LogDebug(string message);
        void LogDebug(Exception? exception, string message);

        void LogError(string message);
        void LogError(Exception? exception, string message);
    }
}
