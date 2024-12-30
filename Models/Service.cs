namespace APILucasSantosPortfolio.Models;

public enum Status { Completed, InProgress, NotStarted }
public class Service
{
    public int ServiceId { get; set; }
    public string? ServiceName { get; set; }
    public int ServiceDuration { get; set; }
    public DateTime ServiceStartDate { get; set; }
    public DateTime ServiceEndDate { get; set; }
    public Status ServiceStatus { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
}

