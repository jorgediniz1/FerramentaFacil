using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerramentaFacil.Application.DTOs;
using FerramentaFacil.Application.Extensions;
using FerramentaFacil.Application.Interfaces;
using FerramentaFacil.Domain.Interfaces.Repository;

namespace FerramentaFacil.Application.Services
{  
    public class FerramentaService : IFerramentaService
    {
        private readonly IFerramentaRepository _ferramentaRepository;

        public FerramentaService(IFerramentaRepository ferramentaRepository)
        {
            _ferramentaRepository = ferramentaRepository;
        }

        public async Task AdicionarAsync(FerramentaDTO ferramentaDto)
        {
            var ferramenta = ferramentaDto.ToEntity();
            await _ferramentaRepository.AdicionarAsync(ferramenta);
        }

        public async Task AtualizarAsync(FerramentaDTO ferramentaDto)
        {
            var ferramenta = ferramentaDto.ToEntity();
            await _ferramentaRepository.AtualizarAsync(ferramenta);
        }

        public async Task DeletarAsync(int ferramentaId)
        {
            var ferramenta = await _ferramentaRepository.ObterPorIdAsync(ferramentaId);
            await _ferramentaRepository.DeletarAsync(ferramenta);
        }

        public async Task<FerramentaDTO> ObterPorCategoriaAsync(int categoriaId)
        {
            var ferramenta = await _ferramentaRepository.ObterPorCategoriaAsync(categoriaId);
            return ferramenta.ToDto();
        }

        public async Task<FerramentaDTO> ObterPorIdAsync(int? ferramentaId)
        {
            var ferramenta = await _ferramentaRepository.ObterPorIdAsync(ferramentaId);
            return ferramenta.ToDto();
        }

        public async Task<IEnumerable<FerramentaDTO>> ObterTodasAsync()
        {
           var ferramentas =  await _ferramentaRepository.ObterTodasAsync();
            return ferramentas.ToDto();
        }
    }
}
