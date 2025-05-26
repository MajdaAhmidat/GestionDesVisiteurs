using gestion_des_visiteurs.Configuration;
using gestion_des_visiteurs.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_des_visiteurs
{
    public class gestion_des_visiteursDbContext : DbContext
    {
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Superviseur> Superviseurs { get; set; }
        public DbSet<Visiteur> Visiteurs { get; set; }
        public DbSet<Visite> Visites { get; set; }
        public DbSet<Demande> Demandes { get; set; }
        public gestion_des_visiteursDbContext(DbContextOptions<gestion_des_visiteursDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdministrateurConfiguration());

            builder.ApplyConfiguration(new SuperviseurConfiguration());

            builder.ApplyConfiguration(new VisiteurConfiguration());

            builder.ApplyConfiguration(new VisiteConfiguration());

            builder.ApplyConfiguration(new DemandeConfiguration());

            builder.Entity<Demande>()
                .HasOne(d => d.Visiteur)
                .WithMany()
                .HasForeignKey(d => d.idVisiteur)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Demande>()
                .HasOne(d => d.Superviseur)
                .WithMany()
                .HasForeignKey(d => d.idSuperviseur)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
