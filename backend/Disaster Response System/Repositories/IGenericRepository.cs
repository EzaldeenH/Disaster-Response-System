using Disaster_Response_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Disaster_Response_System.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }

}