using wayFinder.Models;
using wayFinder.Repositories;

namespace wayFinder.Services
{
  public class AttendeesService
  {
    private readonly AttendeesRepo _ar;
    private readonly DestinationsService _ds;



    public AttendeesService(AttendeesRepo ar, DestinationsService ds)
    {
      _ar = ar;
      _ds = ds;

    }

    internal Attendee CreateAttendee(Attendee attendeeData)
    {
      return _ar.CreateAttendee(attendeeData);
    }
  }
}