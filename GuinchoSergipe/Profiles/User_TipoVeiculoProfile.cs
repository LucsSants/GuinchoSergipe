using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class User_TipoVeiculoProfile : Profile
{
    public User_TipoVeiculoProfile() { 
        CreateMap<User_TipoVeiculo, ReadUser_TipoVeiculoDto>();
    }
}
