using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class CreateVeiculoDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Modelo é obrigatório")]

    public string Modelo { get; set; }

    [Required(ErrorMessage = "Marca é obrigatório")]

    public string Marca { get; set; }

    [Required(ErrorMessage = "Placa é obrigatório")]

    public string Placa { get; set; }

    [Required(ErrorMessage = "Cor é obrigatório")]

    public string Cor { get; set; }
    [Required(ErrorMessage = "Ano é obrigatório")]

    public int Ano { get; set; }
    [Required(ErrorMessage = "Usuario é obrigatório")]
    public int UsuarioId { get; set; }
    [Required(ErrorMessage = "Tipo de Veiculo é obrigatório")]
    public int TipoVeiculoId { get; set; }
}
