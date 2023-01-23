using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;

namespace MyAnimeList.Persistence.Contexto
{
    public class FontePersist : IFontePersist
    {
        private readonly MyAnimeListContext _context;
        public FontePersist(MyAnimeListContext context)
        {
            _context = context;
        }

        public async Task<Fonte[]> GetAllFontesAsync()
        {
            IQueryable<Fonte> query = _context.Fontes;
            query = query.OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Fonte[]> GetAllFontesByNomeAsync(string nome)
        {
            IQueryable<Fonte> query = _context.Fontes;

            query = query.OrderBy(f => f.Id)
            .Where(d => d.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Fonte> GetFonteByIdAsync(int fonteId)
        {
            IQueryable<Fonte> query = _context.Fontes;

            query = query.OrderBy(f => f.Id)
            .Where(f => f.Id == fonteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}