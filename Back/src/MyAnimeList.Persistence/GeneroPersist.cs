using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;

namespace MyAnimeList.Persistence.Contexto
{
    public class GeneroPersist : IGeneroPersist
    {
        private readonly MyAnimeListContext _context;
        public GeneroPersist(MyAnimeListContext context)
        {
            _context = context;
        }

        public async Task<Genero[]> GetAllGenerosAsync()
        {
            IQueryable<Genero> query = _context.Generos;
            query = query.OrderBy(g => g.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Genero[]> GetAllGenerosByNomeAsync(string nome)
        {
            IQueryable<Genero> query = _context.Generos;

            query = query.OrderBy(g => g.Id)
            .Where(g => g.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Genero> GetGeneroByIdAsync(int generoId)
        {
            IQueryable<Genero> query = _context.Generos;

            query = query.OrderBy(g => g.Id)
            .Where(g => g.Id == generoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}