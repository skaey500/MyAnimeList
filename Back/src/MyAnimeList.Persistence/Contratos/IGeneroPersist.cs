using System.Threading.Tasks;
using MyAnimeList.Domain;

namespace MyAnimeList.Persistence.Contratos
{
    public interface IGeneroPersist
    {
        //GENEROS
        Task<Genero[]> GetAllGenerosByNomeAsync(string nome);
        Task<Genero[]> GetAllGenerosAsync();
        Task<Genero> GetGeneroByIdAsync(int generoId);

    }
}