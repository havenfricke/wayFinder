using System;
using wayFinder.Models;
using wayFinder.Repositories;

namespace wayFinder.Services
{

  public class AttendeeService
  {
    private readonly AttendeeRepo _ar;

    public AttendeeService(AttendeeRepo ar)
    {
      _ar = ar;
    }

    private Attendee Get(int id)
    {
      Attendee found = _ar.Get(id);
      if (found == null)
      {
        throw new Exception("invalid id");
      }
      return found;
    }


    internal Attendee CreateAttendee(Attendee attendeeData)
    {
      Attendee exists = _ar.Get(attendeeData.DestinationId, attendeeData.AccountId);
      if (exists != null)
      {
        return exists;
      }
      return _ar.Create(attendeeData);
    }

    internal void DeleteAttendee(int AttendeeId, string userId)
    {
      Attendee found = Get(AttendeeId);
      if (found.AccountId != userId)
      {
        throw new Exception("You do not have permission to delete");
      }
      _ar.DeleteAttendee(AttendeeId);
    }


  }
}