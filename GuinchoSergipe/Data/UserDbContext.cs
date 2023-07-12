using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GuinchoSergipe.Data;

public class UserDbContext : IdentityDbContext<UserModel>

{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User_TipoVeiculo>()
            .HasOne(u => u.User)
            .WithMany(ut => ut.User_TiposVeiculo)
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<User_TipoVeiculo>()
            .HasOne(u => u.TipoVeiculo)
            .WithMany(ut => ut.User_TiposVeiculo)
            .HasForeignKey(u => u.TipoVeiculoId);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<VeiculoModel> Veiculos { get; set; }
    public DbSet<TipoVeiculoModel> TiposVeiculo { get; set; }

    public DbSet<User_TipoVeiculo> User_TiposVeiculo { get; set; }
}
