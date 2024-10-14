using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("TB_FORNECEDOR")]
    public class FornecedorEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; } = string.Empty;

        [Column("CNPJ")]
        [Required]
        public string CNPJ { get; set; } = string.Empty;

        [Column("ENDERECO")]
        public string Endereco { get; set; } = string.Empty;

        [Column("TELEFONE")]
        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Column("EMAIL")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("CRIADOEM")]
        public DateTime CriadoEm { get; set; }
    }
}
