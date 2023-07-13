using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoVeiculoController : ControllerBase
{
    private UserDbContext _context;
    private IMapper _mapper;

    public TipoVeiculoController(UserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateTipoVeiculo([FromBody] CreateTipoVeiculoDto tipoVeiculoDto)
    {
        TipoVeiculoModel tipoVeiculo = _mapper.Map<TipoVeiculoModel>(tipoVeiculoDto);
        _context.TiposVeiculo.Add(tipoVeiculo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTipoVeiculoById), new { id = tipoVeiculo.Id }, tipoVeiculo);
    }

    [HttpGet("{id}")]
    public IActionResult GetTipoVeiculoById(int id)
    {
        var tipoVeiculo = _context.TiposVeiculo.FirstOrDefault(tipoVeiculo => tipoVeiculo.Id == id);
        if (tipoVeiculo == null) { return NotFound(); }
        var tipoVeiculoDto = _mapper.Map<ReadTipoVeiculoDto>(tipoVeiculo);
        return Ok(tipoVeiculoDto);
    }

    [HttpGet]
    public IEnumerable<ReadTipoVeiculoDto> GetTiposVeiculo([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadTipoVeiculoDto>>(_context.TiposVeiculo.Skip(skip).Take(take).ToList());
    }
}
