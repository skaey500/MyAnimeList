using System.Threading.Tasks;
using MyAnimeList.Domain;

namespace MyAnimeList.Persistence.Contratos
{
    public interface IDemographicPersist
    {
        //DEMOGRAPHICS
        Task<Demographic[]> GetAllDemographicsByNomeAsync(string nome);
        Task<Demographic[]> GetAllDemographicsAsync();
        Task<Demographic> GetDemographicByIdAsync(int demographicId);

    }
}