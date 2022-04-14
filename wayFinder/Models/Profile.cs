namespace wayFinder.Models
{
  public class Profile
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
  }

  public class DestinationAttendeeVM : Profile
  {
    public int AttendeeId { get; set; }
  }
}