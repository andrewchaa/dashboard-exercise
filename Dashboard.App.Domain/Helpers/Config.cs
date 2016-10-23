using System.Configuration;
using Dashboard.App.Domain.Contracts;

namespace Dashboard.App.Domain.Helpers
{
    public class Config : IConfig
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }
    }
}
