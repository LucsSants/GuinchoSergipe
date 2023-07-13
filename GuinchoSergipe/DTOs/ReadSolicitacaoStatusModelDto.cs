using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class ReadSolicitacaoStatusModelDto
{
    public int Id { get; set; }
    public string Status { get; set; }
}
