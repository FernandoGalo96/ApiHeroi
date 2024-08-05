using Denovo.Repository.Interface;
using Herois.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Denovo.Repository;

public class EfCoreRepository : IEfCoreRepository
{
    private readonly HeroiContext _context;

    public EfCoreRepository(HeroiContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<IEnumerable<Heroi>>GetAllHerois()
    {
        IQueryable<Heroi> query = _context.Herois
       .Include(h => h.IdentidadeSecreta)
       .Include(h => h.Armas)
       .Include(h => h.HeroiBatalhas)
           .ThenInclude(hb => hb.Batalha)
       .AsNoTracking()
       .OrderBy(h => h.Id);

        return await query.ToArrayAsync();
    }
     
    public async Task<Heroi> GetHeroiById(int id)
    {
        IQueryable<Heroi> query = _context.Herois
      .Include(h => h.IdentidadeSecreta)
      .Include(h => h.Armas)
      .Include(h => h.HeroiBatalhas)
          .ThenInclude(hb => hb.Batalha)
      .AsNoTracking()
      .OrderBy(h => h.Id);

        return await query.FirstOrDefaultAsync( h => h.Id == id);
    }

    public async Task<Heroi[]> GetHeroiByName(string nome)
    {
        IQueryable<Heroi> query = _context.Herois
      .Include(h => h.IdentidadeSecreta)
      .Include(h => h.Armas)
      .Include(h => h.HeroiBatalhas)
          .ThenInclude(hb => hb.Batalha)
      .AsNoTracking()
      .Where(h => h.Nome.Contains(nome))
      .OrderBy(h => h.Id);

        return await query.ToArrayAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() > 0);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public async Task<Batalha[]> GetBatalhas()
    {
        IQueryable<Batalha> query = _context.Batalhas.Include(h => h.HeroiBatalhas).ThenInclude(h => h.Heroi).AsNoTracking
            ().OrderBy(h => h.Id);  

        return await query.ToArrayAsync();


    }

    public async Task<Batalha> GetBatalhasId( int id)
    {
        IQueryable<Batalha> query = _context.Batalhas.Include(h => h.HeroiBatalhas).ThenInclude(h => h.Heroi).AsNoTracking
            ().OrderBy(h => h.Id);

        return await query.FirstOrDefaultAsync(h => h.Id == id);


    }

   
}
