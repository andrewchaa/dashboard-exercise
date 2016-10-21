using System.Configuration;

namespace Dashboard.App.ImportPnl.Repositories
{
    public class Config : IConfig
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }
    }
}
