using FerramentaFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FerramentaFacil.Infra.Data.EntitiesMappings
{
    public class FerramentaMap : IEntityTypeConfiguration<Ferramenta>
    {
        public void Configure(EntityTypeBuilder<Ferramenta> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.ValorDiaria)
                .HasPrecision(10,2);

            builder.HasOne(c => c.Categoria)
                .WithMany(f => f.Ferramentas)
                .HasForeignKey(c => c.CategoriaId);
        }
    }
}
