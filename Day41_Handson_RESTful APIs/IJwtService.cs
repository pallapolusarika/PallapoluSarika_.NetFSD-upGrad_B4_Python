namespace ApiTestingDemo.Services
{
    public interface IJwtService
    {
        string GenerateToken(string username);
    }
}
