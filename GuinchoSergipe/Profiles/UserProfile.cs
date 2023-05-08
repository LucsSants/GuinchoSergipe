using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;

namespace GuinchoSergipe.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, UserModel>();
    }

}
