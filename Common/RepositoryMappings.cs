using AutoMapper;
using NbaTracker.Models;
using NbaTracker.Repository.DbSets;

namespace NbaTracker.Common
{
    public class RepositoryMappings : Profile
    {
        public RepositoryMappings()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
        }
    }
}
