using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, UserModel>();
        CreateMap<UserModel, ReadUserDto>()
            .ForMember(usuarioDto => usuarioDto.ReadEnderecoDto, opt => opt.MapFrom(usuario => usuario.Endereco));
            
        CreateMap<VeiculoModel, ReadVeiculoDto>();
       

    }

}
