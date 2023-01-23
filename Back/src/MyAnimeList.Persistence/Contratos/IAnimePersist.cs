using System.Threading.Tasks;
using MyAnimeList.Domain;

namespace MyAnimeList.Persistence.Contratos
{
    public interface IAnimePersist
    {
        //ANIMES
        Task<Anime[]> GetAllAnimesByNomeAsync(int userId, string nome);
        Task<Anime[]> GetAllAnimesAsync(int userId);
        Task<Anime> GetAnimeByIdAsync(int userId, int animeId);

    }
}