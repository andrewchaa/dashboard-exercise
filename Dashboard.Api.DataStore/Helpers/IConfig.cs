namespace Dashboard.Api.DataStore.Helpers
{
    public interface IConfig
    {
        string GetConnectionString(string name);
    }
}