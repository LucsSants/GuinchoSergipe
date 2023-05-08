using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class ReadEnderecoDto
{
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
}
