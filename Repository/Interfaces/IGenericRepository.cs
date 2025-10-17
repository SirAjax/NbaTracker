using NbaTracker.Common;

namespace NbaTracker.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<GenericResponse<List<T>>> GetAllAsync();
        Task<GenericResponse<List<T>>> SaveListAsync(List<T> data);
    }
}
