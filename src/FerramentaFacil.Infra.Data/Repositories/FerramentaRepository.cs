using FerramentaFacil.Domain.Entities;
using FerramentaFacil.Domain.Interfaces.Repository;
using FerramentaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FerramentaFacil.Infra.Data.Repositories
{
    public class FerramentaRepository : IFerramentaRepository
    {
        private readonly ApplicationDbContext _ferramentaContext;
        public FerramentaRepository(ApplicationDbContext ferramentaContext)
        {
            _ferramentaContext = ferramentaContext;
        }
        public async Task<Ferramenta> AdicionarAsync(Ferramenta ferramenta)
        {
            _ferramentaContext.Add(ferramenta);

            await _ferramentaContext.SaveChangesAsync();

            return ferramenta;
        }

        public async Task<Ferramenta> AtualizarAsync(Ferramenta ferramenta)
        {
            _ferramentaContext.Update(ferramenta);

            await _ferramentaContext.SaveChangesAsync();

            return ferramenta;

        }

        public async Task<Ferramenta> DeletarAsync(Ferramenta ferramenta)
        {        
            _ferramentaContext.Remove(ferramenta);
           
            await _ferramentaContext.SaveChangesAsync();

            return ferramenta;

        }

        public async Task<Ferramenta> ObterPorCategoriaAsync(int categoriaId)
        {
            return await _ferramentaContext.Ferramentas
                .Include(fc => fc.Categoria)
                .FirstAsync(f => f.CategoriaId == categoriaId);
        }

        public async Task<Ferramenta> ObterPorIdAsync(int? ferramentaId)
        {
            return await _ferramentaContext.Ferramentas.FindAsync(ferramentaId);
        }

        public async Task<IEnumerable<Ferramenta>> ObterTodasAsync()
        {
            return await _ferramentaContext.Ferramentas.ToListAsync();
        }
    }
}
