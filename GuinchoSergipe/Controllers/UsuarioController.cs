using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public UsuarioController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateUsuario([FromBody] CreateUsuarioDto usuarioDTO)
    {
        UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioDTO);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id}")]
    public IActionResult GetUsuarioById(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null) { return NotFound(); }
        var usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
        return Ok(usuarioDto);
    }

    [HttpGet]
    public IEnumerable<ReadUsuarioDto> GetUsuarios([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadUsuarioDto>>(_context.Usuarios.Skip(skip).Take(take).ToList());
    }





}
