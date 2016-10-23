using System.Configuration;

namespace Dashboard.Api.DataStore.Helpers
{
    public class Config : IConfig
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;
        }
    }
}
