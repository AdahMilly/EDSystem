using EDSystem.Models;

namespace EDSystem.Services.IService
{
    public interface IUser
    {
        Task <User> GetUserByEmail (string email);
        Task<string> RegisterUser (User user);
    }
}
