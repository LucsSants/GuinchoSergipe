using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GuinchoSergipe.Controllers;


[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private UserDbContext _context;
    private IMapper _mapper;

    public VeiculoController(UserDbContext context, IMapper mapper)
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

    [HttpGet("user/{id}")]
    public IActionResult GetVeiculoByUserId(string id)
    {
        List<VeiculoModel> veiculo = _context.Veiculos.Where(v=> v.UserId == id).ToList();
        if (veiculo == null) { return NotFound("usuario não encontrado"); }
        var veiculoDto = _mapper.Map<List<ReadVeiculoDto>>(veiculo);
        return Ok(veiculoDto);
    }

    [HttpGet]
    public IEnumerable<ReadVeiculoDto> GetVeiculos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadVeiculoDto>>(_context.Veiculos.Skip(skip).Take(take).ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateVeiculoDto veiculoDto)
    {
        var filme = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (filme == null) { return NotFound("Usuáio não encontrado"); }
        _mapper.Map(veiculoDto, filme);
        _context.SaveChanges();
        return Ok();
    }
}

