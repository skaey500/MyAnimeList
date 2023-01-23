using System.Threading.Tasks;
using MyAnimeList.Domain;

namespace MyAnimeList.Persistence.Contratos
{
    public interface IEstudioPersist
    {
        //ESTUDIOS
        Task<Estudio[]> GetAllEstudiosByNomeAsync(string nome);
        Task<Estudio[]> GetAllEstudiosAsync();
        Task<Estudio> GetEstudioByIdAsync(int estudioId);

    }
}