namespace Dashboard.App.Domain.Repositories
{
    public interface IConfig
    {
        string GetConnectionString(string name);
    }
}