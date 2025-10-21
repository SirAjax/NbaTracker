using Microsoft.EntityFrameworkCore;
using NbaTracker.Common;
using NbaTracker.Repository.Interfaces;

namespace NbaTracker.Repository
{
    public class GenericRepository<T>(RepositoryContext repositoryContext) : IGenericRepository<T> where T : class
    {
        public async Task<GenericResponse<List<T>>> GetAllAsync()
        {
            var retVal = new GenericResponse<List<T>>();
            try
            {
                retVal.Value = await repositoryContext.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                await retVal.SetExceptionAsync(ex);
            }
            return retVal;
        }

        public async Task<GenericResponse<T>> SaveItemAsync(T item)
        {
            var retVal = new GenericResponse<T>();
            try
            {
                repositoryContext.ChangeTracker.Clear();
                await repositoryContext.AddAsync(item);
                await repositoryContext.SaveChangesAsync();
                retVal.Value = item;
            }
            catch (Exception ex)
            {
                await retVal.SetExceptionAsync(ex);
            }
            return retVal;
        }

        public async Task<GenericResponse<List<T>>> SaveListAsync(List<T> data)
        {
            var retVal = new GenericResponse<List<T>>();
            try
            {
                repositoryContext.ChangeTracker.Clear();
                await repositoryContext.AddRangeAsync(data);
                await repositoryContext.SaveChangesAsync();
                retVal.Value = data;
            }
            catch (Exception ex)
            {
                await retVal.SetExceptionAsync(ex);
            }
            return retVal;
        }

        public async Task<GenericResponse<bool>> DeleteItemAsync(T item)
        {
            var retVal = new GenericResponse<bool>();
            try
            {
                repositoryContext.ChangeTracker.Clear();
                repositoryContext.Remove(item);
                await repositoryContext.SaveChangesAsync();
                retVal.Value = true;
            }
            catch(Exception ex)
            {
                await retVal.SetExceptionAsync(ex);
            }
            return retVal;
        }
    }
}
