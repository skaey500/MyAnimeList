using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;

namespace MyAnimeList.Persistence.Contexto
{
    public class DemographicPersist : IDemographicPersist
    {
        private readonly MyAnimeListContext _context;
        public DemographicPersist(MyAnimeListContext context)
        {
            _context = context;
        }

        public async Task<Demographic[]> GetAllDemographicsAsync()
        {
            IQueryable<Demographic> query = _context.Demographics;
            query = query.OrderBy(d => d.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Demographic[]> GetAllDemographicsByNomeAsync(string nome)
        {
            IQueryable<Demographic> query = _context.Demographics;

            query = query.OrderBy(d => d.Id)
            .Where(d => d.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Demographic> GetDemographicByIdAsync(int demographicId)
        {
            IQueryable<Demographic> query = _context.Demographics;

            query = query.OrderBy(d => d.Id)
            .Where(d => d.Id == demographicId);

            return await query.FirstOrDefaultAsync();
        }
    }
}