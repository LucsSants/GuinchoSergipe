using GuinchoSergipe.Models;

namespace GuinchoSergipe.DTOs;

public class ReadUserDto
{
    public string Id { get; set;}
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto ReadEnderecoDto { get; set; }
    public ICollection<ReadVeiculoDto> Veiculos { get; set; }

    public bool? isGuincho { get; set; }

    public bool? isDisponivel { get; set; }

    public ICollection<ReadUser_TipoVeiculoDto> User_TiposVeiculo { get; set; }

}
