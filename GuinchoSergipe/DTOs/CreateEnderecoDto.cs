using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "Rua é obrigatório")]
    [StringLength(200, ErrorMessage = "Rua deve ser menor que 200 caracteres")]
    public string Rua { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatório")]
    [MaxLength(200, ErrorMessage = "Cidade deve ser menor que 200 caracteres")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório")]
    [StringLength(200, ErrorMessage = "Bairro deve ser menor que 200 caracteres")]

    public string Bairro { get; set; }

   
    [Required]
    [StringLength(8, ErrorMessage = "CEP Precisa ter 8 dígitos", MinimumLength = 8)]
    public string CEP { get; set; }
    

}
