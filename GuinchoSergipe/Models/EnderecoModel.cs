using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class EnderecoModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Rua é obrigatório")]
    [MaxLength(200, ErrorMessage = "Rua deve ser menor que 200 caracteres")]
    public string Rua { get; set;}

    [Required(ErrorMessage = "Cidade é obrigatório")]
    [MaxLength(200, ErrorMessage = "Cidade deve ser menor que 200 caracteres")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório")]
    [MaxLength(200, ErrorMessage = "Bairro deve ser menor que 200 caracteres")]
    public string Bairro { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "CEP deve ter no mínimo 8 dígitos")]
    [MaxLength(8, ErrorMessage = "CEP deve ter no máximo 8 dígitos")]
    public string CEP { get; set; }
    public virtual UserModel User { get; set; }
}
