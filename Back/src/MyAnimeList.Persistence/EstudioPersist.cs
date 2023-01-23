using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;

namespace MyAnimeList.Persistence.Contexto
{
    public class EstudioPersist : IEstudioPersist
    {
        private readonly MyAnimeListContext _context;
        public EstudioPersist(MyAnimeListContext context)
        {
            _context = context;

        }

        public async Task<Estudio[]> GetAllEstudiosAsync()
        {
            IQueryable<Estudio> query = _context.Estudios;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Estudio[]> GetAllEstudiosByNomeAsync(string nome)
        {
            IQueryable<Estudio> query = _context.Estudios;

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Estudio> GetEstudioByIdAsync(int estudioId)
        {
            IQueryable<Estudio> query = _context.Estudios;

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == estudioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}