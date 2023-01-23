using System.Collections.Generic;

namespace MyAnimeList.Domain
{
    public class Estudio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<AnimeEstudio> AnimesEstudios { get; set; }
    }
}