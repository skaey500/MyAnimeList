using System.Threading.Tasks;
using MyAnimeList.Domain;

namespace MyAnimeList.Persistence.Contratos
{
    public interface IFontePersist
    {
        //FONTE
        Task<Fonte[]> GetAllFontesByNomeAsync(string nome);
        Task<Fonte[]> GetAllFontesAsync();
        Task<Fonte> GetFonteByIdAsync(int fonteId);

    }
}