using GuinchoSergipe.Models;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class ReadSolicitacaoDto
{
    public int Id { get; set; }
    public virtual ReadUserDto UserCliente { get; set; }
    public virtual ReadUserDto UserGuincho { get; set; }
    public string VeiculoId { get; set; }
    public virtual ReadVeiculoDto Veiculo { get; set; }
    public string Descricao { get; set; }
    public DateTime SoliitacaoHora { get; set; }
    public ReadSolicitacaoStatusModelDto Status { get; set; }
    public string? Lat { get; set; }
    public string? Long { get; set; }
}
