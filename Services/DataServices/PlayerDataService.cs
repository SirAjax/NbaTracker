using AutoMapper;
using NbaTracker.Common;
using NbaTracker.Models;
using NbaTracker.Repository.DbSets;
using NbaTracker.Repository.ModelRepositories.Interfaces;

namespace NbaTracker.Services.DataServices;

public interface IPlayerDataService
{
    Task<GenericResponse<PlayerDto>> SavePlayer(PlayerDto player);
    Task<GenericResponse<bool>> DeletePlayer(PlayerDto player);
}

public class PlayerDataService(IPlayerRepository playerRepository, IMapper mapper) : IPlayerDataService
{
    public async Task<GenericResponse<PlayerDto>> SavePlayer(PlayerDto player)
    {
        GenericResponse<PlayerDto> retVal = new();
        try
        {
            Player playerToSave = mapper.Map<Player>(player);
            var repositoryResponse = await playerRepository.SaveItemAsync(playerToSave);

            retVal.Value = mapper.Map<PlayerDto>(repositoryResponse);
        }
        catch(Exception ex)
        {
            await retVal.SetExceptionAsync(ex);
        }
        return retVal;
    }

    public async Task<GenericResponse<bool>> DeletePlayer(PlayerDto player)
    {
        GenericResponse<bool> retVal = new();
        try
        {
            Player playerToDelete = mapper.Map<Player>(player);
            await playerRepository.DeleteItemAsync(playerToDelete);
            retVal.Value = true;
        }
        catch(Exception ex)
        {
            await retVal.SetExceptionAsync(ex);
        }
        return retVal;
    }
}
