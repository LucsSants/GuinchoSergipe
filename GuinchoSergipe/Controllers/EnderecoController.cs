using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private UserDbContext _context;
    private IMapper _mapper;

    public EnderecoController(UserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateUsuario([FromBody] CreateEnderecoDto enderecoDto)
    {
        EnderecoModel enderco = _mapper.Map<EnderecoModel>(enderecoDto);
        _context.Enderecos.Add(enderco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEnderecoById), new { id = enderco.Id }, enderco);
    }

    [HttpGet("{id}")]
    public IActionResult GetEnderecoById(int id)
    {
        EnderecoModel enderco = _context.Enderecos.FirstOrDefault(enderco => enderco.Id == id);
        if (enderco == null) { return NotFound(); }
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(enderco);
        return Ok(enderecoDto);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetUsuarios([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }
}
