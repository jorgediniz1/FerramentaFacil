using FerramentaFacil.Application.DTOs;
using FerramentaFacil.Application.Extensions;
using FerramentaFacil.Application.Interfaces;
using FerramentaFacil.Domain.Interfaces.Repository;

namespace FerramentaFacil.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task AdicionarAsync(CategoriaDTO categoriaDto)
        {
            var categoria = categoriaDto.ToEntity();            
            await _categoriaRepository.AdicionarAsync(categoria);

        }

        public async Task AtualizarAsync(CategoriaDTO categoriaDto)
        {
            var categoria = categoriaDto.ToEntity();
            await _categoriaRepository.AtualizarAsync(categoria);
        }

        public async Task DeletarAsync(int? categoriaId)
        {
            var categoria =  await _categoriaRepository.ObterPorIdAsync(categoriaId);
            await _categoriaRepository.DeletarAsync(categoria);
        }

        public async Task<CategoriaDTO> ObterPorIdAsync(int? categoriaId)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(categoriaId);
            return categoria.ToDto();
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterTodasAsync()
        {
            var categorias = await _categoriaRepository.ObterTodasAsync();        
            return categorias.ToDto();
        }
    }
}
