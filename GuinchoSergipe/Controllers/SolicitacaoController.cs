using AutoMapper;
using GuinchoSergipe.Data;
using GuinchoSergipe.DTOs;
using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuinchoSergipe.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitacaoController : ControllerBase
{
    private UserDbContext _context;
    private IMapper _mapper;
    private UserManager<UserModel> _userManager;

    public SolicitacaoController(UserDbContext context, IMapper mapper, UserManager<UserModel> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSolicitacao([FromBody] CreateSolicitacaoDto solicitacaoDto)
    {
        solicitacaoDto.StatusId = 1;
        solicitacaoDto.SoliitacaoHora = DateTime.Now;
        UserModel guincho = await _userManager.FindByIdAsync(solicitacaoDto.UserGuinchoId);
        guincho.isDisponivel = false;
        SolicitacaoModel solicitacao = _mapper.Map<SolicitacaoModel>(solicitacaoDto);
        _context.Solicitacoes.Add(solicitacao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSolicitacaoById), new { id = solicitacao.Id }, solicitacao);
    }

    [HttpPut("{soli_id}/status/{status_id}")]
    public  async Task<IActionResult> UpdateAndamento(int soli_id, int status_id)
    {
        SolicitacaoModel solitacao = _context.Solicitacoes.FirstOrDefault(solicitacao => solicitacao.Id == soli_id);
        if (solitacao == null) { return NotFound(); }
        UserModel guincho = await _userManager.FindByIdAsync(solitacao.UserGuincho.Id);
        if (status_id == 2 && solitacao.StatusId == 4)
        {
            guincho.isDisponivel = true;
            return NotFound();
        }
        else if (status_id == 3 && solitacao.StatusId == 4)
        {
            guincho.isDisponivel = true;
            await _userManager.UpdateAsync(guincho);
            return NotFound();
        }
        if (status_id == 2 && solitacao.StatusId == 1)
        {
            guincho.isDisponivel = false;
            await _userManager.UpdateAsync(guincho);
        }
        else
        {
            guincho.isDisponivel = true;
            await _userManager.UpdateAsync(guincho);
        }
        solitacao.StatusId = status_id;
         _context.SaveChanges();
        
            await _userManager.UpdateAsync(guincho);

        return NoContent();
    }

    [HttpPut("recusado/{id}")]
    public async Task<IActionResult> UpdateRecusado(int id)
    {
        SolicitacaoModel solitacao = _context.Solicitacoes.FirstOrDefault(solicitacao => solicitacao.Id == id);
        if (solitacao == null) { return NotFound(); }
        solitacao.StatusId = 3;
        UserModel guincho = await _userManager.FindByIdAsync(solitacao.UserGuinchoId);
        guincho.isDisponivel = true;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("semresposta/{id}")]
    public async Task<IActionResult> UpdateSemResposta(int id)
    {
        SolicitacaoModel solitacao = _context.Solicitacoes.FirstOrDefault(solicitacao => solicitacao.Id == id);
        if (solitacao == null) { return NotFound(); }
        solitacao.StatusId = 4;
        UserModel guincho = await _userManager.FindByIdAsync(solitacao.UserGuinchoId);
        guincho.isDisponivel = true;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("concluido/{id}")]
    public async Task<IActionResult> UpdateFinalizado(int id)
    {
        SolicitacaoModel solitacao = _context.Solicitacoes.FirstOrDefault(solicitacao => solicitacao.Id == id);
        if (solitacao == null) { return NotFound(); }
        solitacao.StatusId = 5;
        UserModel guincho = await _userManager.FindByIdAsync(solitacao.UserGuinchoId);
        guincho.isDisponivel = true;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("solicitacoesG/{id}")]
    public IActionResult GetSolicitacoesByUserGId(string id)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserGuinchoId == id).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }

    [HttpGet("solicitacoesG/fin/{id}")]
    public IActionResult GetSolicitacoesByUserGFinalizadasId(string id)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserGuinchoId == id && s.StatusId == 3 || s.StatusId == 4 || s.StatusId ==5).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }

    [HttpGet("solicitacoesG/{id}/{status}")]
    public IActionResult GetSolicitacoesByUserGId(string id, int status)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserGuinchoId == id && s.StatusId == status).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }

    [HttpGet("solicitacoesC/{id}")]
    public IActionResult GetSolicitacoesByUserCId(string id)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserClienteId == id).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }

    [HttpGet("solicitacoesC/fin/{id}")]
    public IActionResult GetSolicitacoesByUserFinalizadasCId(string id)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserClienteId == id && s.StatusId == 3 || s.StatusId == 4 || s.StatusId == 5).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }

    [HttpGet("solicitacoesC/{id}/{status}")]
    public IActionResult GetSolicitacoesByUserCId(string id, int status)
    {
        List<SolicitacaoModel> solicitacoes = _context.Solicitacoes.Where(s => s.UserClienteId == id && s.StatusId == status).ToList();
        if (solicitacoes == null) { return NotFound("usuario não encontrado"); }
        var solicitacoesDto = _mapper.Map<List<ReadSolicitacaoDto>>(solicitacoes);
        return Ok(solicitacoesDto);
    }



    [HttpGet("{id}")]
    public IActionResult GetSolicitacaoById(int id)
    {
        SolicitacaoModel solicitacao = _context.Solicitacoes.FirstOrDefault(enderco => enderco.Id == id);
        if (solicitacao == null) { return NotFound(); }
        var solicitacaoDto = _mapper.Map<ReadSolicitacaoDto>(solicitacao);
        return Ok(solicitacaoDto);
    }

}
