using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() {
        CreateMap<CreateUsuarioDto, UsuarioModel>();
        CreateMap<UsuarioModel, ReadUsuarioDto>().ForMember(usuarioDto => usuarioDto.ReadEnderecoDto, opt => opt.MapFrom(usuario => usuario.Endereco));

    }
}
