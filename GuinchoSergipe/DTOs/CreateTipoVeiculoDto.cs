using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class CreateTipoVeiculoDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do tipo é obrigatório")]
    public string TipoNome { get; set; }
}
