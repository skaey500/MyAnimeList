using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAnimeList.Application.Dtos
{
    public class EstudioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<AnimeEstudioDto> AnimesEstudios { get; set; }
    }
}