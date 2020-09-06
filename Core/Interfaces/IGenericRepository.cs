using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}