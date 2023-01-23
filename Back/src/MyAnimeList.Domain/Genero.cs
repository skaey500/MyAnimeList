using System.Collections.Generic;

namespace MyAnimeList.Domain
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<AnimeGenero> AnimesGeneros{ get; set; }
    }
}