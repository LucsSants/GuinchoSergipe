using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class CreateUserDto
{
    [Required]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password, ErrorMessage ="Senha deve conter: Letras maiúsculas e minúsculas, números e caractere especial!")]
    public string Password { get; set; }

    [Required]
    [Compare("Password",ErrorMessage ="Senhas não são iguais")]
    public string PasswordConfirmation { get; set; }

    [Required(ErrorMessage = "Campo CPF é obrigatório")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Campo Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter entre até 100 caracteres!")]
    public string Nome { get; set; }
    public int? EnderecoId { get; set; }
    public bool? isGuincho { get; set; }
    public bool? isDisponivel { get; set; }
    public List<int>? TiposId { get; set; }



}
