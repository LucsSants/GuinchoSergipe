using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        public string Cpf { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        [StringLength(100, ErrorMessage = "Senha deve ser menor que 100 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter entre 5 e 100 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Precisa do Endereço")]
        public int EnderecoId { get; set; }
    }
}
