using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class VeiculoModel
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
    
    public int UsuarioId { get; set; }
    public virtual UsuarioModel usuario { get; set; }

    public int? TipoVeiculoId { get; set; }
    public virtual TipoVeiculoModel TipoVeiculo { get; set; }

}
