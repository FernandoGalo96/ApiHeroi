using AutoMapper;
using Denovo.HeroisContext.Dtos;
using Denovo.Repository.Interface;
using Herois.Context;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Denovo.Controllers;

[ApiController]
[Route("[controller]")]
public class BatalhasController : ControllerBase
{
    private readonly IEfCoreRepository _context;
    private readonly IMapper _mapper;

    public BatalhasController(IEfCoreRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> RecuperaBatalha()
    {
        var batalhas = await _context.GetBatalhas();
        var batalhasDto = _mapper.Map<IEnumerable<ReadBatalhaDto>>(batalhas);
        return Ok(batalhasDto);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionaBatalha(CreateBatalhaDto batalhaDto)
    {
        var batalha = _mapper.Map<Batalha>(batalhaDto);
        _context.Add(batalha);

        if (await _context.SaveChangesAsync())
        {
            return Ok("Batalha salva com sucesso.");
        }
        else
        {
            return BadRequest("Erro ao salvar batalha.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBatalha(int id, UpdateBatalhaDto batalhaDto)
    {
        var batalha = await _context.GetBatalhasId(id);
        if (batalha == null) return NotFound("Batalha não encontrada.");

        // Atualiza as propriedades da batalha existente com os dados do DTO
        _mapper.Map(batalhaDto, batalha);
        _context.Update(batalha);

        if (await _context.SaveChangesAsync())
        {
            return Ok("Batalha atualizada com sucesso.");
        }
        else
        {
            return BadRequest("Erro ao atualizar batalha.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaBatalha(int id)
    {
        var batalha = await _context.GetBatalhasId(id);
        if (batalha == null) return NotFound("Batalha não encontrada.");

        _context.Delete(batalha);

        if (await _context.SaveChangesAsync())
        {
            return Ok("Batalha deletada com sucesso.");
        }
        else
        {
            return BadRequest("Erro ao deletar batalha.");
        }
    }
}
