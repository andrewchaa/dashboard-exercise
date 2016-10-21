using System.Configuration;

namespace Dashboard.App.Domain.Repositories
{
    public class Config : IConfig
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }
    }
}
