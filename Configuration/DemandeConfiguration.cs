using gestion_des_visiteurs.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gestion_des_visiteurs.Configuration
{
    public class DemandeConfiguration : IEntityTypeConfiguration<Demande>
    {
        public void Configure(EntityTypeBuilder<Demande> builder)
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
               .Property(p => p.description)
               .IsRequired();

            builder
                .ToTable("Demandes");
        }
    }
}
