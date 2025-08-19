using FerramentaFacil.Application.DTOs;
using FerramentaFacil.Domain.Entities;

namespace FerramentaFacil.Application.Extensions
{
    public static class FerramentaExtensions
    {
        public static FerramentaDTO ToDto(this Ferramenta ferramenta)
        {
            if (ferramenta is null) return null;

            return new FerramentaDTO
            {
                Id = ferramenta.Id,
                Nome = ferramenta.Nome,
                Descricao = ferramenta.Descricao,
                ValorDiaria = ferramenta.ValorDiaria,
                Estoque = ferramenta.Estoque,
                Imagem = ferramenta.Imagem,
                CategoriaId = ferramenta.CategoriaId,
                Categoria = ferramenta.Categoria
            };
        }

        public static Ferramenta? ToEntity(this FerramentaDTO ferramentaDto)
        {
            if (ferramentaDto is null) return null;

            return new Ferramenta(
                ferramentaDto.Id,
                ferramentaDto.Nome,
                ferramentaDto.Descricao,
                ferramentaDto.ValorDiaria,
                ferramentaDto.Estoque,
                ferramentaDto.Imagem
                );

        }

        public static IEnumerable<FerramentaDTO> ToDto(this IEnumerable<Ferramenta> ferramentas)
        {
            if (ferramentas is null) return null;

            return ferramentas.Select(f => f.ToDto());
        }
    }
}
