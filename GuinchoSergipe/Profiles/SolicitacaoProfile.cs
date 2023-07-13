using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class SolicitacaoProfile : Profile
{
    public SolicitacaoProfile()
    {
        CreateMap<CreateSolicitacaoDto, SolicitacaoModel>();
        CreateMap<SolicitacaoModel, ReadSolicitacaoDto>();
    }
}
