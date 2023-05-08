using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class TipoVeiculoProfile : Profile
{
    public TipoVeiculoProfile()
    {
        CreateMap<CreateTipoVeiculoDto, TipoVeiculoModel>();
        CreateMap<TipoVeiculoModel, ReadTipoVeiculoDto>();
    }
}
