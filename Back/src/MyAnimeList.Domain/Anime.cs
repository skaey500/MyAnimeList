using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MyAnimeList.Domain.Identity;

namespace MyAnimeList.Domain
{

    public class Anime
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Episodios { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime? DataLancamento { get; set; }
        public IEnumerable<AnimeGenero> Generos { get; set; }
        public IEnumerable<AnimeEstudio> Estudios { get; set; }

    }
}