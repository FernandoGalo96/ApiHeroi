namespace Models;

public class IdentidadeSecreta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int HeroiId { get; set; }
    public Heroi Heroi { get; set; }
}