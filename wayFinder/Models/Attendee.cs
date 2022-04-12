namespace wayFinder.Models
{
  public class Attendee
  {
    public int Id { get; set; }
    public int DestinationId { get; set; }
    public Account Account { get; set; }
  }

}