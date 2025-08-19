using FerramentaFacil.Domain.Validation;

namespace FerramentaFacil.Domain.Entities
{
    public sealed class Categoria : EntityBase
    {
        public string Nome { get; private set; }
      
        
        public ICollection<Ferramenta> Ferramentas { get; private set; }

        public Categoria(string nome)
        {
            ValidateDomain(nome);        
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");
            Id = id;
            ValidateDomain(nome);
        }

        public void Atualizar(string nome)
        {
            ValidateDomain(nome);
            Nome = nome;
        }


        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é requerido.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. Mínimo 3 caracteres.");
            DomainExceptionValidation.When(nome.Length > 100, "Nome inválido. Máximo 100 caracteres.");
            
            Nome = nome;
        }
    }
}
