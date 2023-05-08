using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile() { 
        CreateMap<CreateEnderecoDto, EnderecoModel>();
        CreateMap<EnderecoModel, ReadEnderecoDto>();

    }
}
