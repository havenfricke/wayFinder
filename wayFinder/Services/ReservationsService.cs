using System;
using System.Collections.Generic;
using wayFinder.Models;

namespace wayFinder.Services
{
  public class ReservationsService
  {
    private readonly ReservationsRepo _rr;
    private readonly DestinationsRepo _ds;

    public ReservationsService(ReservationsRepo rr, DestinationsRepo ds)
    {
      _rr = rr;
      _ds = ds;
    }

    internal List<Reservation> GetAllResrByDestId(int id)
    {
      return _rr.GetAllResrByDestId(id);
    }

    internal Reservation CreateReservation(Reservation resrData)
    {
      return _rr.CreateReservation(resrData);
    }

    internal void DeleteReservation(int id, Account userInfo)
    {
      Reservation resr = _rr.GetReservationById(id);
      if (resr.CreatorId == userInfo.Id)
      {
        _rr.DeleteReservation(id);
      }
      else
      {
        throw new Exception("Not yours to delete");
      }
    }
  }
}