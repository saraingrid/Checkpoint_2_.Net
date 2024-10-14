using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 e no máximo 150 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Telefone)} é obrigatório")]
        [Phone(ErrorMessage = "O telefone não é válido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Email)} é obrigatório")]
        [EmailAddress(ErrorMessage = "O email não é válido")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [Required(ErrorMessage = $"Campo {nameof(DataNascimento)} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [StringLength(250, ErrorMessage = "O endereço pode ter no máximo 250 caracteres")]
        public string Endereco { get; set; } = string.Empty;

        [DataType(DataType.Date, ErrorMessage = "Data de contratação inválida")]
        [Required(ErrorMessage = $"Campo {nameof(DataContratacao)} é obrigatório")]
        public DateTime DataContratacao { get; set; }

        [Range(0, 100, ErrorMessage = "O percentual de comissão deve estar entre 0 e 100")]
        public decimal ComissaoPercentual { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A meta mensal deve ser um valor positivo")]
        public decimal MetaMensal { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de criação inválida")]
        public DateTime CriadoEm { get; set; }
    }
}
