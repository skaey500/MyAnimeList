using System;
using System.Threading.Tasks;
using MyAnimeList.Application.Dtos;
using MyAnimeList.Application.Contratos;
using MyAnimeList.Domain;
using MyAnimeList.Persistence.Contratos;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyAnimeList.Application
{
    public class AnimeService : IAnimeService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IAnimePersist _animePersist;
        private readonly IMapper _mapper;
        public AnimeService(IGeralPersist geralPersist, IAnimePersist animePersist, IMapper mapper)
        {
            _animePersist = animePersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<AnimeDto> AddAnime(int userId, AnimeDto model)
        {
            try
            {
                var anime = _mapper.Map<Anime>(model);
                anime.UserId = userId;

                _geralPersist.Add<Anime>(anime);
                if (await _geralPersist.SaveChangesAsync())
                {
                    await _geralPersist.SaveChangesAsync();
                    
                    var animeretorno = await _animePersist.GetAnimeByIdAsync(userId, anime.Id);
                    return _mapper.Map<AnimeDto>(animeretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<AnimeDto> UpdateAnime(int userId, int animeId, AnimeDto model)
        {
            try
            {
                var anime = await _animePersist.GetAnimeByIdAsync(userId, animeId);
                if (anime == null) return null;

                model.UserId = userId;
                
                _mapper.Map(model, anime);

                _geralPersist.Update<Anime>(anime);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var animeretorno = await _animePersist.GetAnimeByIdAsync(userId, anime.Id);
                    return _mapper.Map<AnimeDto>(animeretorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteAnime(int userId, int animeId)
        {
            try
            {
                var anime = await _animePersist.GetAnimeByIdAsync(userId, animeId);
                if (anime == null) throw new Exception("Anime para delete não encontrado.");

                _geralPersist.Delete<Anime>(anime);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AnimeDto[]> GetAllAnimesAsync(int userId)
        {
            try
            {
                var animes = await _animePersist.GetAllAnimesAsync(userId);
                if (animes == null) return null;

                var resultado = _mapper.Map<AnimeDto[]>(animes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AnimeDto[]> GetAllAnimesByNomeAsync(int userId, string nome)
        {
            try
            {
                var animes = await _animePersist.GetAllAnimesByNomeAsync(userId, nome);
                if (animes == null) return null;

                var resultado = _mapper.Map<AnimeDto[]>(animes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AnimeDto> GetAnimeByIdAsync(int userId, int animeId)
        {
            try
            {
                var anime = await _animePersist.GetAnimeByIdAsync(userId, animeId);
                if (anime == null) return null;

                var resultado = _mapper.Map<AnimeDto>(anime);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}