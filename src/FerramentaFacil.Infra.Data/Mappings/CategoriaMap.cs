using FerramentaFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FerramentaFacil.Infra.Data.EntitiesMappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasData(
                new Categoria(1, "Pintura"),
                new Categoria(2, "Funilaria")
                );
        }
    }
}
