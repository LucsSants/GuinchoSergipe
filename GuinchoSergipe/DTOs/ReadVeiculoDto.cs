using GuinchoSergipe.Models;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.DTOs
{
    public class ReadVeiculoDto
    {   
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public String UserId { get; set; }

        public ReadTipoVeiculoDto TipoVeiculo { get; set; }
    }
}
