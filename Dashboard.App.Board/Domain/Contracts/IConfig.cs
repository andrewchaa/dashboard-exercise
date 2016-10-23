namespace Dashboard.App.Board.Domain.Contracts
{
    public interface IConfig
    {
        string GetConnectionString(string name);
        string AppSettings(string key);
    }
}