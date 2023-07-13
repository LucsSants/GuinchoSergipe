using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class SolicitacaoStatusModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Status { get; set; }
    public virtual ICollection<SolicitacaoModel> Solicitacoes { get;}
}
