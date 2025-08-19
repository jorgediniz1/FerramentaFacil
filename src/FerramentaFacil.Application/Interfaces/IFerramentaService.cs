using FerramentaFacil.Application.DTOs;

namespace FerramentaFacil.Application.Interfaces
{
    public interface IFerramentaService
    {
        Task<IEnumerable<FerramentaDTO>> ObterTodasAsync();
        Task<FerramentaDTO> ObterPorIdAsync(int? ferramentaId);
        Task<FerramentaDTO> ObterPorCategoriaAsync(int categoriaId);
        Task AdicionarAsync(FerramentaDTO ferramentaDto);
        Task AtualizarAsync(FerramentaDTO ferramentaDto);
        Task DeletarAsync(int ferramentaId);
    }
}
