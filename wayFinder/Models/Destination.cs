namespace wayFinder.Models
{
  public class Destination
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatorId { get; set; }

    public Profile TripHost { get; set; }
  }

  public class AttendeeDestinationVM : Destination
  {
    public int AttendeeId { get; set; }
  }
}