using gestion_des_visiteurs.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gestion_des_visiteurs.Configuration
{
    public class VisiteConfiguration : IEntityTypeConfiguration<Visite>
    {
        public void Configure(EntityTypeBuilder<Visite> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();

            builder
                .Property(p => p.dateVisite)
                .IsRequired();

            builder
               .Property(p => p.heureDebut)
               .IsRequired();

            builder
               .Property(p => p.heureFin)
               .IsRequired();

            builder
               .Property(p => p.duree)
               .IsRequired();

            builder
               .Property(p => p.idVisiteur)
               .IsRequired();

            builder
                .ToTable("Visites");
        }
    }
}
