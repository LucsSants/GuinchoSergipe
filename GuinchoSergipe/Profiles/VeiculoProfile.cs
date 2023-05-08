using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<CreateVeiculoDto, VeiculoModel>();
        CreateMap<VeiculoModel, ReadVeiculoDto>();
    }
}
