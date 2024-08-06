using Models;

namespace Denovo.HeroisContext.Dtos;

public class CreateHeroiDto
{
    public string Nome { get; set; }
    public IEnumerable<HeroiBatalha> HeroiBatalhas { get; set; }
    public IEnumerable<Arma> Armas { get; set; }

    public IdentidadesSecretas IdentidadeSecreta { get; set; }
}
