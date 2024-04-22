using dummy.Models;
using Microsoft.EntityFrameworkCore;

namespace dummy.Data
{
    public class pgdbContext : DbContext
    {
        public pgdbContext(DbContextOptions<pgdbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Shift> shifts { get; set; }
    }
}
