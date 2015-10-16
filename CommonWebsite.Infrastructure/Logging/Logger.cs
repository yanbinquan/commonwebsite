namespace CommonWebsite.Infrastructure.Logging
{
    public class Logger
    {
        private static readonly ILogger ErrorLogger;

        static Logger()
        {
            ErrorLogger = new CommonLogger();
        }

        public static void Error(object message)
        {
            ErrorLogger.Log(message);
        }
    }
}
