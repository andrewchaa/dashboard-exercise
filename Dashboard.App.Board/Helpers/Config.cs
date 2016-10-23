using System.Configuration;
using Dashboard.App.Board.Domain.Contracts;

namespace Dashboard.App.Board.Helpers
{
    public class Config : IConfig
    {
        public string AppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
