using Microsoft.EntityFrameworkCore;
using NbaTracker.Repository.DbSets;

namespace NbaTracker.Repository
{
    public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
    }
}
