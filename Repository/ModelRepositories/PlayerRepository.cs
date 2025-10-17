using NbaTracker.Repository.DbSets;
using NbaTracker.Repository.ModelRepositories.Interfaces;

namespace NbaTracker.Repository.ModelRepositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
