using FerramentaFacil.Domain.Entities;
using FerramentaFacil.Domain.Validation;

namespace FerramentaFacil.Domain.Tests.Entities
{
    public class FerramentaTests
    {

        [Fact(DisplayName = "Criar ferramenta com parâmetros válidos")]
        public void CriarFerramenta_ComParametrosValidos_DeveCriarObjeto()
        {
            var ferramenta = new Ferramenta
             (
                1,
                "Pincél 3 pol Vonder",
                "Para reformas ou retoques no ambiente residencial",
                4.99m,
                15,
                "pincel3pol.jpg"
             );

            Assert.Equal(1, ferramenta.Id);
            Assert.Equal("Pincél 3 pol Vonder", ferramenta.Nome);
            Assert.Equal("Para reformas ou retoques no ambiente residencial", ferramenta.Descricao);
            Assert.Equal(4.99m, ferramenta.Valor);
            Assert.Equal(15, ferramenta.Estoque);
            Assert.Equal("pincel3pol.jpg", ferramenta.Imagem);
        }

        [Fact(DisplayName = "Criar ferramenta com ID negativo lança exceção")]
        public void CriarFerramenta_ComIdNegativo_DeveLancarException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(-1, "Pincél 3 pol Vonder", "Para reformas ou retoques no ambiente residencial", 4.99m, 15, "pincel3pol.jpg"));

            Assert.Equal("Valor de Id inválido.", ex.Message);
        }

        [Fact(DisplayName = "Criar ferramenta com nome curto lança exceção")]
        public void CriarFerramenta_ComNomeCurto_DeveLancarException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(1, "Pi", "Para reformas ou retoques no ambiente residencial", 4.99m, 15, "pincel3pol.jpg"));

            Assert.Equal("Nome inválido. Mínimo 3 caracteres.", ex.Message);
        }

        [Fact(DisplayName = "Criar ferramenta com nome da imagem longo lança exceção")]
        public void CriarFerramenta_ComNomeImagemLongo_DeveLancarException()
        {
            var nomeImagemLongo = new string('a', 251);

            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(1, "Pincél 3 pol Vonder", "Para reformas ou retoques no ambiente residencial", 4.99m, 15, nomeImagemLongo));

            Assert.Equal("Imagem inválida. Máximo 250 caracteres", ex.Message);
        }

        [Fact(DisplayName = "Criar ferramenta com nome da imagem null não lança exceção")]
        public void CriarFerramenta_ComNomeImagemNull_NaoDeveLancarException()
        {
            try
            {
            var ex =  new Ferramenta(1, "Pincél 3 pol Vonder", "Para reformas ou retoques no ambiente residencial", 4.99m, 15, null);
            }
            catch (NullReferenceException)
            {
                Assert.Fail("Lançou NullReferenceException");
            }

        }

        [Fact(DisplayName = "Criar ferramenta com descrição curta lança exceção")]
        public void CriarFerramenta_ComDescricaoCurta_DeveLancarException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(1, "Pincél 3 pol Vonder", "Para", 4.99m, 15, "pincel3pol.jpg"));

            Assert.Equal("Descrição inválida. Mínimo 5 caracteres", ex.Message);
        }


        [Theory(DisplayName = "Criar ferramenta com estoque negativo lança exceção")]
        [InlineData(-1)]
        [InlineData(-5)]
        public void CriarFerramenta_ComNomeEstoqueNegativo_DeveLancarException(int estoqueInvalido)
        {

            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(1, "Pincél 3 pol Vonder", "Para reformas ou retoques no ambiente residencial", 4.99m, estoqueInvalido, null!));

            Assert.Equal("Estoque inválido. Estoque não pode ser negativo", ex.Message);
        }


        [Theory(DisplayName = "Criar ferramenta com valor negativo lança exceção")]
        [InlineData(-3.99)]
        [InlineData(-5.99)]
        public void CriarFerramenta_ComValorNegativo_DeveLancarException(int valorInvalido)
        {

            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Ferramenta(1, "Pincél 3 pol Vonder", "Para reformas ou retoques no ambiente residencial", valorInvalido, 15, null!));

            Assert.Equal("Valor inválido. Valor não pode ser negativo.", ex.Message);
        }


    }
}
