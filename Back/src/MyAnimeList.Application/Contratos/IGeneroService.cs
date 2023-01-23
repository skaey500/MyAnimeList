using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAnimeList.Application.Dtos;

namespace MyAnimeList.Application.Contratos
{
    public interface IGeneroService
    {
        Task<GeneroDto> AddGenero(GeneroDto model);
        Task<GeneroDto> UpdateGenero(int generoId, GeneroDto model);
        Task<bool> DeleteGenero(int generoId);

        Task<GeneroDto[]> GetAllGenerosAsync();
        Task<GeneroDto[]> GetAllGenerosByNomeAsync(string nome);
        Task<GeneroDto> GetGeneroByIdAsync(int generoId);
    }
}