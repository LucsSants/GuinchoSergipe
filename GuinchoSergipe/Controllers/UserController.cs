using AutoMapper;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using GuinchoSergipe.Services;
using Microsoft.AspNetCore.Authorization;
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
    private UserManager<UserModel> _userManager;

    public UserController(UserService userService, UserManager<UserModel> userManager)
    {
        _userService = userService;
        _userManager = userManager;
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
        userDto.isDisponivel = true;
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

    [Authorize]
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
    [Authorize]
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
    [Authorize]
    [HttpGet("status/{id}")]
    public async Task<IActionResult> getUserStatus(string id)
    {
        var result = await _userService.getUserStatus(id);
        if (result == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        return Ok(result);
    }
    [Authorize]
    [HttpPost("status/{id}")]
    public async Task<IActionResult> changeUserStatus(string id)
    {
        var resultado = await _userService.changeUserStatus(id);
        if (resultado == "Sucesso")
        {
            return Ok(resultado);
        }
        return NotFound(resultado);
    }

}
