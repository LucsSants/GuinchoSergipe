using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GuinchoSergipe.Models;

public class UserModel : IdentityUser
{

    [Required(ErrorMessage = "Campo CPF é obrigatório")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Campo Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter entre até 100 caracteres!")] 
    public string Nome { get; set; }
    
    public UserModel(): base() { }
    public int? EnderecoId { get; set; }
    public virtual EnderecoModel Endereco { get; set; }
    public virtual ICollection<VeiculoModel> Veiculos { get; set; }

    public bool? isGuincho { get; set; }

    public bool? isDisponivel { get; set; }

    public virtual ICollection<User_TipoVeiculo> User_TiposVeiculo { get; set; }
    
}
