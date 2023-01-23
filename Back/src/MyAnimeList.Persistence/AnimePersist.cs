using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;

namespace MyAnimeList.Persistence.Contexto
{
    public class AnimePersist : IAnimePersist
    {
        private readonly MyAnimeListContext _context;
        public AnimePersist(MyAnimeListContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Anime[]> GetAllAnimesAsync(int userId)
        {
            IQueryable<Anime> query = _context.Animes
            .Include(a => a.Generos)
            .Include(a => a.Estudios);
            query = query.Where(a => a.UserId == userId).OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Anime[]> GetAllAnimesByNomeAsync(int userId, string nome)
        {
            IQueryable<Anime> query = _context.Animes
           .Include(a => a.Generos)
           .Include(a => a.Estudios);

            query = query.OrderBy(a => a.Id)
            .Where(a => a.Nome.ToLower().Contains(nome.ToLower()) && 
                    a.UserId == userId);

            return await query.ToArrayAsync();
        }

        public async Task<Anime> GetAnimeByIdAsync(int userId, int animeId)
        {
            IQueryable<Anime> query = _context.Animes
           .Include(a => a.Generos)
           .Include(a => a.Estudios);

            query = query.OrderBy(a => a.Id)
            .Where(a => a.Id == animeId && a.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }


    }
}