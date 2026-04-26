using CorridaAPI.Models;
namespace CorridaAPI.Repositories;
public interface ICorridaRepository {
    Task<IEnumerable<Corrida>> GetAllAsync();
    Task<Corrida> GetByIdAsync(int id);
    Task AddAsync(Corrida corrida);
    Task UpdateAsync(Corrida corrida);
    Task DeleteAsync(int id);
}