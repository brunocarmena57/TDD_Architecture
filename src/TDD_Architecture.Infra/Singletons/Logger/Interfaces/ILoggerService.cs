﻿namespace TDD_Architecture.Infra.Singletons.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
