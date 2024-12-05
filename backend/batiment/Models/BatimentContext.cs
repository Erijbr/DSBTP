//using batiment.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BatimentsApi.Models
//{
//    public class BatimentContext : DbContext
//    {
//        public BatimentContext(DbContextOptions<BatimentContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<User> Users { get; set; }
//        public DbSet<Temoignage> Temoignages { get; set; }
//        public DbSet<Service> Services { get; set; }
//        public DbSet<Projet> Projets { get; set; }
//        public DbSet<RendezVous> RendezVous { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}

using batiment.Models;
using Microsoft.EntityFrameworkCore;
using batiment.models;

namespace BatimentsApi.Models
{
    public class BatimentContext : DbContext
    {
        public BatimentContext(DbContextOptions<BatimentContext> options)
            : base(options)
        {
        }

        public DbSet<user> Users { get; set; }
        public DbSet<Temoignage> Temoignages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des entités ici
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BatimentContext).Assembly);

            // Exemple de configuration manuelle :
            modelBuilder.Entity<user>(entity =>
            {
                entity.HasKey(e => e.Id); // Définir la clé primaire
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique(); // Email unique
            });

            modelBuilder.Entity<Temoignage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Appreciation).IsRequired();
                entity.HasOne<user>()
                     .WithMany() // Vous pouvez spécifier le nom de la collection si nécessaire
                     
                     .OnDelete(DeleteBehavior.Cascade); // Choisissez le comportement de suppression approprié

            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Projet>(entity =>
            {
                entity.HasKey(e => e.Id);
              
            });

            modelBuilder.Entity<RendezVous>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Définir la relation avec User
                entity.HasOne<user>()
                      .WithMany() // Vous pouvez spécifier le nom de la collection si nécessaire
                      
                      .OnDelete(DeleteBehavior.Cascade); // Choisissez le comportement de suppression approprié
            });

        }
    }
}
