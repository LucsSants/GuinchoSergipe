using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity;

namespace GuinchoSergipe.Services;

public class UserService
{
    private IMapper _mapper;
    private  UserManager<UserModel> _userManager;
    private SignInManager<UserModel> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<UserModel> userManager = null, SignInManager<UserModel> signInManager = null, TokenService tokenService = null)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }


    public async Task Cadastra(CreateUserDto userDto)
    {
        UserModel user = _mapper.Map<UserModel>(userDto);

        await _userManager.SetUserNameAsync(user, userDto.Email);
        IdentityResult resultado = await _userManager.CreateAsync(user, userDto.Password);

        if (!resultado.Succeeded) { 
        throw new ApplicationException("Falha ao cadastrar usuario");
        }
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuario não autenticado");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Email.ToUpper());
       

        var token = await _tokenService.GenerateToken(user);

        return token;
    }
}
 