using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using GuinchoSergipe.Services;
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
        await _userService.Cadastra(userDto);
        return Ok("Usuario Cadastrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult>  Login( LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(new {token = token, email = dto.Email});
    }
}
