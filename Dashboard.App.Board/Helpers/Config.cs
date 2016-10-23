using System.Configuration;
using Dashboard.App.Board.Domain.Contracts;

namespace Dashboard.App.Board.Helpers
{
    public class Config : IConfig
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }

        public string AppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
