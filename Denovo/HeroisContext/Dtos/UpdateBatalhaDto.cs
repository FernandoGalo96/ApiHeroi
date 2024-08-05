namespace Denovo.HeroisContext.Dtos;

public class UpdateBatalhaDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public List<int> HeroiIds { get; set; }
}