using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class UsuarioModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo CPF é obrigatório")]
    public string Cpf { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Campo Senha é obrigatório")]
    [MaxLength(100, ErrorMessage = "Senha deve ser menor que 100 caracteres")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "Campo Nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "Nome deve ter entre 5 e 100 caracteres!")]
    public string Nome { get; set; }

}
