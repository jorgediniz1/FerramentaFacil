using FerramentaFacil.Domain.Entities;

namespace FerramentaFacil.Domain.Interfaces.Repository
{
    public interface IFerramentaRepository
    {
        Task<IEnumerable<Ferramenta>> ObterTodasAsync();
        Task<Ferramenta> ObterPorIdAsync(int? ferramentaId);
        Task<Ferramenta> ObterPorCategoriaAsync(int categoriaId);
        Task<Ferramenta> AdicionarAsync(Ferramenta ferramenta);
        Task<Ferramenta> AtualizarAsync(Ferramenta ferramenta);
        Task<Ferramenta> DeletarAsync(Ferramenta ferramenta);
    }
}
