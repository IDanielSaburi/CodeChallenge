using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMotorcycleRepository
    {
        Task<Motorcycle> GetByIdAsync(int id);
        Task<IEnumerable<Motorcycle>> GetAllAsync();
        Task AddAsync(Motorcycle motorcycle);
        Task UpdateAsync(Motorcycle motorcycle);
        Task DeleteAsync(Motorcycle motorcycle);
    }
}
