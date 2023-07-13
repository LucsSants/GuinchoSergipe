using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity;
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

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "CLIENTE", NormalizedName = "CLIENTE".ToUpper() },
            new IdentityRole { Id = "2", Name = "GUINCHO", NormalizedName = "GUINCHO".ToUpper() },
            new IdentityRole { Id = "3", Name = "ADMIN", NormalizedName = "ADMIN".ToUpper() }
            ) ;

        modelBuilder.Entity<TipoVeiculoModel>().HasData(
           new TipoVeiculoModel { Id = 1, TipoNome = "Motocicleta"},
           new TipoVeiculoModel { Id = 2, TipoNome = "Carro" }
           
           );

        modelBuilder.Entity<SolicitacaoStatusModel>().HasData(
          new SolicitacaoStatusModel { Id = 1, Status = "PENDENTE" },
          new SolicitacaoStatusModel { Id = 2, Status = "EM_ANDAMENTO"},
          new SolicitacaoStatusModel { Id = 3, Status = "RECUSADO" },
          new SolicitacaoStatusModel { Id = 4, Status = "SEM_RESPOSTA" },
          new SolicitacaoStatusModel { Id = 5, Status = "CONCLUIDO" }
          );




        base.OnModelCreating(modelBuilder);
    }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<VeiculoModel> Veiculos { get; set; }
    public DbSet<TipoVeiculoModel> TiposVeiculo { get; set; }
    public DbSet<SolicitacaoModel> Solicitacoes { get; set; }
    public DbSet<SolicitacaoStatusModel> SolicitacaoStatus { get; set; }
    public DbSet<User_TipoVeiculo> User_TiposVeiculo { get; set; }
}
