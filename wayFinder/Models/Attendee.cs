using System;

namespace wayFinder.Models
{
  public class Attendee
  {
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int DestinationId { get; set; }

    public string AccountId { get; set; }
  }
}