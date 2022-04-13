namespace wayFinder.Models
{
  public class Destination
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatorId { get; set; }
  }

  public class DestinationVM : Destination
  {
    public int? DestAttId { get; set; }
    public Account? DestAtt { get; set; }
  }
}