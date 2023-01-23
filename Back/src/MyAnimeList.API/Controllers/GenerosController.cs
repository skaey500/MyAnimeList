using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyAnimeList.Application.Dtos;
using MyAnimeList.Application.Contratos;


namespace MyAnimeList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GenerosController(IGeneroService generoService)
        {
            _generoService = generoService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var generos = await _generoService.GetAllGenerosAsync();
                if (generos == null) return NoContent();

                return Ok(generos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar generos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var genero = await _generoService.GetGeneroByIdAsync(id);
                if (genero == null) return NoContent();

                return Ok(genero);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar generos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var generos = await _generoService.GetAllGenerosByNomeAsync(nome);
                if (generos == null) return NoContent();

                return Ok(generos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar generos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeneroDto model)
        {
            try
            {
                var generos = await _generoService.AddGenero(model);
                if (generos == null) return NoContent();

                return Ok(generos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar generos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GeneroDto model)
        {
            try
            {
                var genero = await _generoService.UpdateGenero(id, model);
                if (genero == null) return NoContent();

                return Ok(genero);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar generos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var generos = await _generoService.GetGeneroByIdAsync(id);
                if (generos == null) return NoContent();

                return await _generoService.DeleteGenero(id) ?
                       Ok(new {message = "Deletado"}) :
                       throw new Exception("Ocorreu um problema não específico ao tentar deletar o Gênero.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar generos. Erro: {ex.Message}");
            }
        }
    }
}