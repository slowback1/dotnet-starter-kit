using System;
using Slowback.Logger.LoggingEngines;

namespace Common.Utilities.Logging.LoggingEngines;

public class ConsoleLoggingEngine : ILoggingEngine
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}