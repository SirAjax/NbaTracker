using NbaTracker.Common;
using NbaTracker.Models;
using NbaTracker.Repository.ModelRepositories.Interfaces;

namespace NbaTracker.Services.DataServices;

public class PlayerDataService(IPlayerRepository playerRepository)
{
    public async Task<GenericResponse<PlayerDto>> SavePlayer(PlayerDto player)
    {

    }
}
