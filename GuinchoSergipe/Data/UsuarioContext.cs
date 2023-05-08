using GuinchoSergipe.Models;
using Microsoft.EntityFrameworkCore;

namespace GuinchoSergipe.Data;

public class UsuarioContext : DbContext
{
    public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
    {

    }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<VeiculoModel> Veiculos { get; set;}
    public DbSet<TipoVeiculoModel> TiposVeiculo { get; set; }
}
