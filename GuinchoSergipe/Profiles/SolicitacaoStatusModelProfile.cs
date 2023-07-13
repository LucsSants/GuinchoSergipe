using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class SolicitacaoStatusModelProfile : Profile
{
    public SolicitacaoStatusModelProfile()
    {
        CreateMap<SolicitacaoStatusModel, ReadSolicitacaoStatusModelDto>();

    }
}

