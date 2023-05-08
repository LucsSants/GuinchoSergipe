using GuinchoSergipe.Models;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class ReadUsuarioDto
{
  
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto ReadEnderecoDto { get; set; }
    public ICollection<ReadVeiculoDto> Veiculos { get; set; }
}
