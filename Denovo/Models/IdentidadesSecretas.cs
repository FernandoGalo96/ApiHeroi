namespace Models;

public class IdentidadesSecretas
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int HeroiId { get; set; }
    public Heroi Heroi { get; set; }
}