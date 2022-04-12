using System;

namespace wayFinder.Models
{
  public class Reservation
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public string Type { get; set; }

    public string Confirmation { get; set; }

    public string Address { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; }

    public int Cost { get; set; }

    public string CreatorId { get; set; }

    public int DestinationId { get; set; }
  }
}