using FerramentaFacil.Domain.Entities;
using FerramentaFacil.Domain.Interfaces.Repository;
using FerramentaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FerramentaFacil.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext categoriaContext)
        {
            _categoriaContext = categoriaContext;
        }
        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
           
            await _categoriaContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            _categoriaContext.Update(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeletarAsync(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> ObterPorIdAsync(int? categoriaId)
        {
            return await _categoriaContext.Categorias.FindAsync(categoriaId);
        }

        public async Task<IEnumerable<Categoria>> ObterTodasAsync()
        {
            return await _categoriaContext.Categorias.ToListAsync();
        }
    }
}
