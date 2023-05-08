using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<UserModel> _userMamager;

    public UserController(IMapper mapper, UserManager<UserModel> userMamager)
    {
        _mapper = mapper;
        _userMamager = userMamager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUsuario( CreateUserDto userDto)
    {
       UserModel user = _mapper.Map<UserModel>(userDto);
        IdentityResult resultado = await _userMamager.CreateAsync(user, userDto.Password);

        if (resultado.Succeeded) return Ok("Usuario Cadastrado");
        throw new ApplicationException("Falha ao cadastrar usuario");
    }
}
