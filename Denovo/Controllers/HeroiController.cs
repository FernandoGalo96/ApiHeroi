using Denovo.Repository.Interface;
using Herois.Context;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Denovo.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroiController : ControllerBase
{
    private readonly IEfCoreRepository _context;

    public HeroiController(IEfCoreRepository context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> RecuperaHerois()
    { 
        var herois = await _context.GetAllHerois();
        return Ok(herois);
        
    }
    [HttpPost]
    public async Task<IActionResult> AdicionaHeroi(Heroi model)
    {
        try
        {
           _context.Add(model);
            if (await _context.SaveChangesAsync()) 
            {
                return Ok("Sucesso");
            } else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Heroi model)
    {
        try
        {
            var heroi = await _context.GetHeroiById(id);
            if (heroi == null) return NotFound();
            heroi.Nome = model.Nome;
            heroi.IdentidadeSecreta = model.IdentidadeSecreta;
            heroi.Armas = model.Armas;
            heroi.HeroiBatalhas = model.HeroiBatalhas;
           
            _context.Update(model); 
             if(await _context.SaveChangesAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            

            

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]

    public async Task<IActionResult> DeletaHeroi (int id)
    {
        var heroi = await _context.GetHeroiById(id);
        if (heroi == null) return NotFound();
        _context.Delete(heroi);
        if (await _context.SaveChangesAsync())
        {
            return Ok("Deletado");
        }
        else
        {
            return BadRequest();
        }

    }
}