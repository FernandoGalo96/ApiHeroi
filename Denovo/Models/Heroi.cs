namespace Models;

public class Heroi

{
    public int Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<HeroiBatalha> HeroiBatalhas { get; set; }
    public IEnumerable<Arma> Armas { get; set; }

    public IdentidadesSecretas IdentidadeSecreta { get; set; }
}