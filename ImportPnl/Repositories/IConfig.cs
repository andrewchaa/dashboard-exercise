namespace Dashboard.App.ImportPnl.Repositories
{
    public interface IConfig
    {
        string GetConnectionString(string name);
    }
}