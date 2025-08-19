using FerramentaFacil.Domain.Entities;
using FerramentaFacil.Domain.Validation;

namespace FerramentaFacil.Domain.Tests.Entities
{
    public class CategoriaTests
    {
        [Fact(DisplayName = "Criar categoria com parâmetros válidos")]
        public void CriarCategoria_ComParametrosValidos_DeveAdicionarCategoria()
        {
            var categoria = new Categoria(1, "Pintura");

            Assert.Equal(1, categoria.Id);
            Assert.Equal("Pintura", categoria.Nome);         
        }


        [Fact(DisplayName ="Criar categoria com id negativo lança Exception")]
        public void CriarCategoria_ComIdNegativo_DeveLancarException()
        {
            var categoriaEx = Assert.Throws<DomainExceptionValidation>(() => new Categoria(-1, "Pintura"));

            Assert.Equal("Valor de Id inválido.", categoriaEx.Message);           
        }


        [Fact(DisplayName = "Criar categoria com nome muito pequeno lança Exception")]
        public void CriarCategoria_ComNomeCurto_DeveLancarException()
        {
            var categoriaEx = Assert.Throws<DomainExceptionValidation>(() => new Categoria(1, "Pi"));

            Assert.Equal("Nome inválido. Mínimo 3 caracteres.", categoriaEx.Message);
        }

        [Fact(DisplayName = "Criar categoria com nome muito longo lança Exception")]
        public void CriarCategoria_ComNomeLongo_DeveLancarException()
        {

            var nomeMuitoLongo = new string('a', 101);

            var categoriaEx = Assert.Throws<DomainExceptionValidation>(() => new Categoria(1, nomeMuitoLongo));

            Assert.Equal("Nome inválido. Máximo 100 caracteres.", categoriaEx.Message);
        }


        [Fact(DisplayName = "Criar categoria com nome vazio lança Exception")]
        public void CriarCategoria_NomeVazio_DeveLancarException()
        {
            var categoriaEx = Assert.Throws<DomainExceptionValidation>(() => new Categoria(1, ""));
           
            Assert.Equal("Nome inválido. Nome é requerido.", categoriaEx.Message);
        }


        [Fact(DisplayName = "Criar categoria com nome nulo lança Exception")]
        public void CriarCategoria_NomeNulo_DeveLancarException()
        {
            var categoriaEx = Assert.Throws<DomainExceptionValidation>(() => new Categoria(1, null!));

            Assert.Equal("Nome inválido. Nome é requerido.", categoriaEx.Message);
        }
     

    }
}
