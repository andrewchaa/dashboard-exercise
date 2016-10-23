namespace Dashboard.App.Domain.Contracts
{
    public interface IConfig
    {
        string GetConnectionString(string name);
    }
}