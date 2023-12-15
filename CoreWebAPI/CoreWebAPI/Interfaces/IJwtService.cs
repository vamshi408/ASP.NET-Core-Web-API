namespace CoreWebAPI.Interfaces
{
    public interface IJwtService
    {
        string Authentication(string username, string password);
    }
}
