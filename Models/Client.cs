namespace APILucasSantosPortfolio.Models;
public class Client
{
    public int ClientId { get; set; }
    public string? ClientName { get; set; }
    public string? ClientContact { get; set; }

    public ICollection<Service>? Services { get; set; }
}
