using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAnimeList.Application.Dtos
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public System.DateTime? DataLancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório."),
         //MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres."),
         //MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres.")
         StringLength(50, MinimumLength = 3,
                          ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Episódios")]
        [Range(1, 26, ErrorMessage = "{0} não pode ser menor que 1 e maior que 26")]
        public int Episodios { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                          ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public IEnumerable<AnimeGeneroDto> Generos { get; set; }
        public IEnumerable<AnimeEstudioDto> Estudios { get; set; }
    }
}