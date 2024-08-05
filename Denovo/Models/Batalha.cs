namespace Models;

public class Batalha
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public DateTime DtInicio { get; set; } = DateTime.Now;

    public DateTime DtFim { get; set; } = DateTime.Now;

    public IEnumerable<HeroiBatalha> HeroiBatalhas { get; set; }
}