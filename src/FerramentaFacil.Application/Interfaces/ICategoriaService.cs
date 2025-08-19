using FerramentaFacil.Application.DTOs;

namespace FerramentaFacil.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> ObterTodasAsync();
        Task<CategoriaDTO> ObterPorIdAsync(int? categoriaId);
        Task AdicionarAsync(CategoriaDTO categoriaDto);
        Task AtualizarAsync(CategoriaDTO categoriaDto);
        Task DeletarAsync(int? categoriaId);
    }
}
