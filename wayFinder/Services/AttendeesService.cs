using System;
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


    internal DestinationVM Create(Attendee attendeeData)
    {
      Attendee atten = _ar.Create(attendeeData);
      DestinationVM dest = _ds.GetViewModelById(attendeeData.DestinationId);

      dest.DestAttId = attendeeData.Id;
      return dest;
    }
  }
}