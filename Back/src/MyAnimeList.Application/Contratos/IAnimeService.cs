using System.Threading.Tasks;
using MyAnimeList.Application.Dtos;


namespace MyAnimeList.Application.Contratos
{
    public interface IAnimeService
    {
        Task<AnimeDto> AddAnime(int userId, AnimeDto model);
        Task<AnimeDto> UpdateAnime(int userId, int animeId, AnimeDto model);
        Task<bool> DeleteAnime(int userId, int animeId);

        Task<AnimeDto[]> GetAllAnimesAsync(int userId);
        Task<AnimeDto[]> GetAllAnimesByNomeAsync(int userId, string nome);
        Task<AnimeDto> GetAnimeByIdAsync(int userId, int animeId);
    }
}