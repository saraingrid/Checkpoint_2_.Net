using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O campo deve ter no mínimo 5 e no máximo 150 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(CNPJ)} é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter exatamente 14 caracteres")]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Email)} é obrigatório")]
        [EmailAddress(ErrorMessage = "O email não é válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Telefone)} é obrigatório")]
        [Phone(ErrorMessage = "O telefone não é válido")]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "O endereço pode ter no máximo 250 caracteres")]
        public string Endereco { get; set; } = string.Empty;

        [DataType(DataType.Date, ErrorMessage = "Data de criação inválida")]
        public DateTime CriadoEm { get; set; }
    }
}
