using Models;

namespace Denovo.Repository.Interface;

public interface IEfCoreRepository 
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;

    void Delete<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

    Task<IEnumerable<Heroi>> GetAllHerois();

    Task<Heroi> GetHeroiById(int id);

    Task<Heroi[]> GetHeroiByName(string name);

    Task<Batalha[]> GetBatalhas();

    Task<Batalha> GetBatalhasId(int id);

    
}
