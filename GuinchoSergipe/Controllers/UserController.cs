using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using GuinchoSergipe.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CreateUsuario( CreateUserDto userDto)
    {
        var result = await _userService.CadastraUsuario(userDto);
        if (result != "Usuario Cadastrado!!!!!!!!")
        {
            return BadRequest(result);
        }
        
        return Ok(result);

       
    }

    [HttpPost("login")]
    public async Task<IActionResult>  Login( LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(new {token = token, email = dto.Email});
    }
}
