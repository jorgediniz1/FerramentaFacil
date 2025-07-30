using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FerramentaFacil.Domain.Entities;

namespace FerramentaFacil.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObterTodasAsync();
        Task<Categoria> ObterPorIdAsync(int? categoriaId);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<Categoria> DeletarAsync(Categoria categoria);

    }
}
