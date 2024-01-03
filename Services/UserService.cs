using EDSystem.Data;
using EDSystem.Models;
using EDSystem.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace EDSystem.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.User.Where(x=>x.Email.ToLower()==email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<string> RegisterUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return "User Added Successfully";
        }
    }
}
