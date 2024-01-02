using EDSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace EDSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //create tables
        public DbSet<User> User { get; set; }

        public DbSet<Course> Course { get; set; }
    }
}
