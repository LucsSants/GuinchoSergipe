using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using GuinchoSergipe.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost("cadastroguincho")]
    public async Task<IActionResult> CreateUsuarioGuincho(CreateUserDto userDto)
    {
        userDto.isGuincho = true;
        userDto.isDisponivel = false;
        var result = await _userService.CadastraUsuarioGuincho(userDto);
        if (result != "Guincho Cadastrado!!!!!!!!")
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

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var result = await _userService.GetUserByEmail(email);
        if (result == null) {
            return NotFound("Usuário não encontrado!");
        }
        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var result = await _userService.GetUserById(id);
        if (result == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        return Ok(result);
    }

    [HttpGet("guinchos")]
    public async Task<IActionResult> GetUserGuinchos()
    {
        var result = await _userService.GetGuinchos();
        if (result == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        return Ok(result);
    }

}
