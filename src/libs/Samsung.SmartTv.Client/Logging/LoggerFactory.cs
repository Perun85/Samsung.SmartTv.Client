namespace Samsung.SmartTv.Client.Logging
{
    public static class LoggerFactory
    {
        public static ILogger Create(ILogger? logger, bool useConsoleLogger)
        {
            if (logger != null)
                return logger;

            if(useConsoleLogger)
                return new ConsoleLogger();

            return new MockLogger();
        }
    }
}