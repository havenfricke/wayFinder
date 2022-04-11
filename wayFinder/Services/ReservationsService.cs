using Microsoft.AspNetCore.Mvc;
using wayFinder.Repositories;

namespace wayFinder.Services
{
  public class ReservationsService
  {
    private readonly ReservationsRepo _rr;

    public ReservationsService(ReservationsRepo rr)
    {
      _rr = rr;
    }
  }
}