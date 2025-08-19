using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FerramentaFacil.Application.DTOs;
using FerramentaFacil.Domain.Entities;

namespace FerramentaFacil.Application.Extensions
{
    public static class CategoriaExtension
    {
        public static CategoriaDTO ToDto(this Categoria categoria)
        {
            if (categoria is null) return null;

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };
        }

        public static Categoria? ToEntity(this CategoriaDTO categoriaDTO)
        {
            if(categoriaDTO is null) return null;

            return new Categoria(
                categoriaDTO.Id,
                categoriaDTO.Nome
            );
        }

        public static IEnumerable<CategoriaDTO> ToDto(this IEnumerable<Categoria> categorias)
        {
            if (categorias is null) return null;
            return categorias.Select(c => c.ToDto());
        }


    }
}
