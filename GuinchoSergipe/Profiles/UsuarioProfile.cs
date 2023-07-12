using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() {
        CreateMap<CreateUsuarioDto, UsuarioModel>();

    }
}
