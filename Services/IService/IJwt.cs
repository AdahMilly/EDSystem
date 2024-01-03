using EDSystem.Models;

namespace EDSystem.Services.IService
{
    public interface IJwt
    {
        string GenerateToken(User user);
    }
}
