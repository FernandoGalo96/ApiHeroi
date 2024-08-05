using Models;

namespace Denovo.HeroisContext.Dtos;

public class ReadBatalhaDto
{
  
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public IEnumerable<HeroiBatalha> HeroiBatalhas { get; set; }
}
