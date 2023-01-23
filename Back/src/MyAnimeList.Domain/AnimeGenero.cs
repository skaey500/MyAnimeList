using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAnimeList.Domain
{
    public class AnimeGenero
    {
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }

    }
}