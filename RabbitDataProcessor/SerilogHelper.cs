using Serilog;
using Serilog.Core;

namespace RabbitDataProcessor
{
    public static class SerilogHelper
    {
        public static Logger BuildSerilog()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger = logger;

            return logger;
        }
    }
}