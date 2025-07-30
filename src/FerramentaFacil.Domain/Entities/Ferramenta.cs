using FerramentaFacil.Domain.Validation;

namespace FerramentaFacil.Domain.Entities
{
    public sealed class Ferramenta : EntityBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Ferramenta(string nome, string descricao, decimal valor, int estoque, string imagem)
        {
            ValidateDomain(nome, descricao, valor, estoque, imagem);
        }

        public Ferramenta(int id, string nome, string descricao, decimal valor, int estoque, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, descricao, valor, estoque, imagem);

        }

        public void Editar(string nome, string descricao, decimal valor, int estoque, string imagem, int categoriaId)
        {
            ValidateDomain(nome, descricao, valor, estoque, imagem);
            CategoriaId = categoriaId;

        }

        private void ValidateDomain(string nome, string descricao, decimal valor, int estoque, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é requerido");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. Mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é requerida");
            DomainExceptionValidation.When(descricao.Length < 5, "Descrição inválida. Mínimo 5 caracteres");
            DomainExceptionValidation.When(valor < 0, "Valor inválido. Valor não pode ser negativo.");
            DomainExceptionValidation.When(estoque < 0, "Estoque inválido. Estoque não pode ser negativo");
            DomainExceptionValidation.When(imagem?.Length > 250, "Imagem inválida. Máximo 250 caracteres");

            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
            Imagem = imagem;

        }
    }
}
