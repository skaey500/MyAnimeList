using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Application.Contratos;
using Microsoft.AspNetCore.Http;
using MyAnimeList.Application.Dtos;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using MyAnimeList.API.Controllers.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace MyAnimeList.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService _animeService;
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnimesController(IAnimeService animeService, IWebHostEnvironment hostEnvironment
                                , IAccountService accountService)
        {
            _hostEnvironment = hostEnvironment;
            _animeService = animeService;
            _accountService = accountService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var animes = await _animeService.GetAllAnimesAsync(User.GetUserId());
                if (animes == null) return NoContent();

                return Ok(animes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar animes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var anime = await _animeService.GetAnimeByIdAsync(User.GetUserId(), id);
                if (anime == null) return NoContent();

                return Ok(anime);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar animes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var animes = await _animeService.GetAllAnimesByNomeAsync(User.GetUserId(), nome);
                if (animes == null) return NoContent();

                return Ok(animes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar animes. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image/{animeId}")]
        public async Task<IActionResult> UploadImage(int animeId)
        {
            try
            {
                var anime = await _animeService.GetAnimeByIdAsync(User.GetUserId(), animeId);
                if (anime == null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    DeleteImage(anime.ImagemURL);
                    anime.ImagemURL = await SaveImage(file);
                }

                var AnimeRetorno = await _animeService.UpdateAnime(User.GetUserId(), animeId, anime);

                return Ok(AnimeRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar animes. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnimeDto model)
        {
            try
            {
                var anime = await _animeService.AddAnime(User.GetUserId(), model);
                if (anime == null) return NoContent();

                return Ok(anime);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar animes. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AnimeDto model)
        {
            try
            {
                var anime = await _animeService.UpdateAnime(User.GetUserId(), id, model);
                if (anime == null) return NoContent();

                return Ok(anime);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar animes. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var anime = await _animeService.GetAnimeByIdAsync(User.GetUserId(), id);
                if (anime == null) return NoContent();

                if (await _animeService.DeleteAnime(User.GetUserId(), id))
                {
                    DeleteImage(anime.ImagemURL);
                    return Ok(new { message = "Deletado" });
                }
                else
                {

                    throw new Exception("Ocorreu um problema não específico ao tentar deletar Anime.");

                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar animes. Erro: {ex.Message}");
            }
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                              .Take(10)
                                              .ToArray()
                                              ).Replace(' ', '-');
            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}