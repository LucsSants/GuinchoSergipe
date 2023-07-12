using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Migrations;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Collections.Generic;

namespace GuinchoSergipe.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<UserModel> _userManager;
    private SignInManager<UserModel> _signInManager;
    private TokenService _tokenService;
    private UserDbContext _context;

    public UserService(UserDbContext context,IMapper mapper, UserManager<UserModel> userManager = null, SignInManager<UserModel> signInManager = null, TokenService tokenService = null)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _context = context;
    }


    public async Task<String> CadastraUsuario(CreateUserDto userDto)
    {
        UserModel user = _mapper.Map<UserModel>(userDto);

        await _userManager.SetUserNameAsync(user, userDto.Email);
        IdentityResult resultado = await _userManager.CreateAsync(user, userDto.Password);

        if (!resultado.Succeeded) {
            List<IdentityError> errorList = resultado.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));
            return errors;
        }else
        {
            await _userManager.AddToRoleAsync(user, "CLIENTE") ;
            return "Usuario Cadastrado!!!!!!!!";
        }
    }

    public async Task<String> CadastraUsuarioGuincho(CreateUserDto userDto)
    {
        UserModel user = _mapper.Map<UserModel>(userDto);

        await _userManager.SetUserNameAsync(user, userDto.Email);
        IdentityResult resultado = await _userManager.CreateAsync(user, userDto.Password);

        if (!resultado.Succeeded)
        {
            List<IdentityError> errorList = resultado.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));
            return errors;
        }
        else
        {
            await _userManager.AddToRoleAsync(user, "GUINCHO");
            var userid = await _userManager.FindByNameAsync(userDto.Email);
            foreach (var id in userDto.TiposId)
            {
                var user_tipos = new User_TipoVeiculo()
                {
                    TipoVeiculoId = id,
                    UserId = userid.Id
                };
                _context.User_TiposVeiculo.Add(user_tipos);
                _context.SaveChanges();
            }
            return "Guincho Cadastrado!!!!!!!!";
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

    public async Task<ReadUserDto> GetUserByEmail(string Email)
    {
        var resultado = await _userManager.FindByNameAsync(Email);
        if(resultado !=null)
        {
            var usuarioDto = _mapper.Map<ReadUserDto>(resultado);
            return usuarioDto;
        }
        return null;
        
    }

    public async Task<List<ReadUserDto>> GetGuinchos()
    {
        List<UserModel> resultado = await _userManager.Users.Where(user => user.isGuincho == true).ToListAsync();
        if (resultado != null)
        {
            var usuarioDto = _mapper.Map<List<ReadUserDto>>(resultado);
            return usuarioDto;
        }
        return null;

    }
}
 