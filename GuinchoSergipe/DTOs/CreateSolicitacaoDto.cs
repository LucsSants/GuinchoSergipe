using GuinchoSergipe.Models;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class CreateSolicitacaoDto
{
    public string UserClienteId { get; set; }
    public string UserGuinchoId { get; set; }
    public int VeiculoId { get; set; }
    public int StatusId { get; set; }
    public string Descricao { get; set; }
    public DateTime? SoliitacaoHora { get; set; }
    public string? Lat { get; set; }
    public string? Long { get; set; }
}
