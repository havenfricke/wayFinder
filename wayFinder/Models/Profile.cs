namespace wayFinder.Models
{
  public class Profile
  {
    public string Name { get; set; }
    public string Picture { get; set; }
  }

  public class ProfileVM : Profile
  {
    public int DestinationId { get; set; }
  }
}