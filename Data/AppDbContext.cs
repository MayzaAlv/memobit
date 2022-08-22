using memobit.Models;
using Microsoft.EntityFrameworkCore;

namespace memobit.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
