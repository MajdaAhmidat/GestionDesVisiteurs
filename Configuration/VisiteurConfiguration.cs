using gestion_des_visiteurs.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gestion_des_visiteurs.Configuration
{
    public class VisiteurConfiguration : IEntityTypeConfiguration<Visiteur>
    {
        public void Configure(EntityTypeBuilder<Visiteur> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();

            builder
               .Property(p => p.nom)
               .IsRequired();

            builder
               .Property(p => p.prenom)
               .IsRequired();

            builder
               .Property(p => p.email)
               .IsRequired();

            builder
               .Property(p => p.telephone)
               .IsRequired();

            builder
                .Property(p => p.cin)
                .IsRequired();

            builder
                .Property(p => p.idSuperviseur)
                .IsRequired();

            builder
                .ToTable("Visiteurs");
        }
    }
}
