using System.Configuration;
using NLog;

namespace Dashboard.Api.DataStore.Helpers
{
    public class Config : IConfig
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public string GetConnectionString(string name)
        {
            Logger.Info("Getting the connection string of {0}", name);

            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }
    }
}
