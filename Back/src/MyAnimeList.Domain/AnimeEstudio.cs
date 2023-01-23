using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAnimeList.Domain
{
    public class AnimeEstudio
    {
        public int EstudioId { get; set; }
        public Estudio Estudio { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}