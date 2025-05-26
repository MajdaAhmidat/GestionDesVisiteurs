using gestion_des_visiteurs.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gestion_des_visiteurs.Configuration
{
    public class AdministrateurConfiguration : IEntityTypeConfiguration<Administrateur>
    {
        public void Configure(EntityTypeBuilder<Administrateur> builder)
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
                .ToTable("Administrateurs");
        }
    }
}
