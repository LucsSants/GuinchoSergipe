using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class TipoVeiculoModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string TipoNome { get; set; }

    public virtual ICollection<VeiculoModel> Veiculos { get; set; }

    public virtual ICollection<User_TipoVeiculo> User_TiposVeiculo { get; set; }
}
