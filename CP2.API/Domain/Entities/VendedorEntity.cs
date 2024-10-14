using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("TB_VENDEDOR")]
    public class VendedorEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NOME")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("TELEFONE")]
        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Column("EMAIL")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("DATANASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("ENDERECO")]
        public string Endereco { get; set; } = string.Empty;

        [Column("DATACONTRATACAO")]
        public DateTime DataContratacao { get; set; }

        [Column("COMISSAOPERCENTUAL")]
        public Decimal ComissaoPercentual { get; set; }

        [Column("METAMENSAL")]
        public Decimal MetaMensal {  get; set; }

        [Column("CRIADOEM")]
        public DateTime CriadoEm { get; set; }

    }
}
