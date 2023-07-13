using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class SolicitacaoModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string UserClienteId { get; set; }
    public virtual UserModel UserCliente { get; set; }
    public string UserGuinchoId { get; set; }
    public virtual UserModel UserGuincho { get; set; }
    public int VeiculoId { get; set; }
    public virtual VeiculoModel Veiculo { get; set; }
    public int StatusId { get; set; }
    public virtual SolicitacaoStatusModel Status { get; set; }
    public string Descricao { get; set; }
    public DateTime SoliitacaoHora { get; set; }
    public string? Lat { get; set; }
    public string? Long { get; set; }
    
}
