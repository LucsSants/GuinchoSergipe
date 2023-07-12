using GuinchoSergipe.Migrations;

namespace GuinchoSergipe.Models;

public class User_TipoVeiculo
{
    public int Id { get; set; }
    public int TipoVeiculoId { get; set; }
    public virtual TipoVeiculoModel TipoVeiculo { get; set; }
    public string UserId { get; set; }
    public virtual UserModel User { get; set; }

    
}
