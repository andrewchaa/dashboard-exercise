namespace Dashboard.App.Board.Helpers
{
    public interface IConfig
    {
        string GetConnectionString(string name);
    }
}