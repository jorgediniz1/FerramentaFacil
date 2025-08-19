using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using FerramentaFacil.Domain.Entities;

namespace FerramentaFacil.Application.DTOs
{
    public class FerramentaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da ferramenta é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O nome da ferramenta é obrigatório.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
        public string Descricao { get;  set; }

        [Required(ErrorMessage = "O valor da ferramenta é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal ValorDiaria { get; set; }

        [Required(ErrorMessage = "O estoque da ferramenta é obrigatório.")]
        public int Estoque { get;  set; }

        [MaxLength(250, ErrorMessage = "Imagem inválida. Máximo 250 caracteres")]
        public string Imagem { get;  set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


       
    }
}
