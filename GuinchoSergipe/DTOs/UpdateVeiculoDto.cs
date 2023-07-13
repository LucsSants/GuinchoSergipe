using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs;

public class UpdateVeiculoDto
{
    public string Modelo { get; set; }


    public string Marca { get; set; }


    public string Placa { get; set; }


    public string Cor { get; set; }

    public int Ano { get; set; }
}
