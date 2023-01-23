using System.Threading.Tasks;
using MyAnimeList.Application.Dtos;

namespace MyAnimeList.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}