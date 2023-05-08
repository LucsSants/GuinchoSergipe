using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;


[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public VeiculoController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateVeiculo([FromBody] CreateVeiculoDto veiculoDto)
    {
        VeiculoModel veiculo = _mapper.Map<VeiculoModel>(veiculoDto);
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
    }

    [HttpGet("{id}")]
    public IActionResult GetVeiculoById(int id)
    {
        VeiculoModel veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (veiculo == null) { return NotFound(); }
        ReadVeiculoDto veiculoDto = _mapper.Map<ReadVeiculoDto>(veiculo);
        return Ok(veiculoDto);
    }

    [HttpGet]
    public IEnumerable<ReadVeiculoDto> GetVeiculos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadVeiculoDto>>(_context.Veiculos.Skip(skip).Take(take).ToList());
    }
}
