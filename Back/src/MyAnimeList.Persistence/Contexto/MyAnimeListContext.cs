
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Domain.Identity;

namespace MyAnimeList.Persistence.Contexto
{
    public class MyAnimeListContext : IdentityDbContext<User, Role, int, 
                                                       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
                                                       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MyAnimeListContext(DbContextOptions<MyAnimeListContext> options) : base(options) { }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Fonte> Fontes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UserRole>(userRole =>
           {
               userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

               userRole.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.RoleId)
                   .IsRequired();

               userRole.HasOne(ur => ur.User)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();

           });

            modelBuilder.Entity<AnimeEstudio>()
            .HasKey(AE => new { AE.AnimeId, AE.EstudioId });

            modelBuilder.Entity<AnimeGenero>()
            .HasKey(AG => new { AG.AnimeId, AG.GeneroId });

        }


    }
}