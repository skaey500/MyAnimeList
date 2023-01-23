using System;
using System.Threading.Tasks;
using MyAnimeList.Application.Dtos;
using MyAnimeList.Application.Contratos;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;
using AutoMapper;


namespace MyAnimeList.Application
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IGeneroPersist _generoPersist;
        private readonly IMapper _mapper;
        public GeneroService(IGeralPersist geralPersist, IGeneroPersist generoPersist, IMapper mapper)
        {
            _generoPersist = generoPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<GeneroDto> AddGenero(GeneroDto model)
        {
            try
            {
                var genero = _mapper.Map<Genero>(model);

                _geralPersist.Add<Genero>(genero);
                if (await _geralPersist.SaveChangesAsync())
                {    
                    var generoretorno = await _generoPersist.GetGeneroByIdAsync(genero.Id);
                    return _mapper.Map<GeneroDto>(generoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<GeneroDto> UpdateGenero(int generoId, GeneroDto model)
        {
            try
            {
                var genero = await _generoPersist.GetGeneroByIdAsync(generoId);
                if (genero == null) return null;

                _mapper.Map(model, genero);

                _geralPersist.Update<Genero>(genero);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var generoretorno = await _generoPersist.GetGeneroByIdAsync(genero.Id);
                    return _mapper.Map<GeneroDto>(generoretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteGenero(int generoId)
        {
            try
            {
                var genero = await _generoPersist.GetGeneroByIdAsync(generoId);
                if (genero == null) throw new Exception("genero para delete não encontrado.");

                _geralPersist.Delete<Genero>(genero);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GeneroDto[]> GetAllGenerosAsync()
        {
            try
            {
                var generos = await _generoPersist.GetAllGenerosAsync();
                if (generos == null) return null;

                var resultado = _mapper.Map<GeneroDto[]>(generos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GeneroDto[]> GetAllGenerosByNomeAsync(string nome)
        {
            try
            {
                var generos = await _generoPersist.GetAllGenerosByNomeAsync(nome);
                if (generos == null) return null;

                var resultado = _mapper.Map<GeneroDto[]>(generos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GeneroDto> GetGeneroByIdAsync(int generoId)
        {
            try
            {
                var genero = await _generoPersist.GetGeneroByIdAsync(generoId);
                if (genero == null) return null;

                var resultado = _mapper.Map<GeneroDto>(genero);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}