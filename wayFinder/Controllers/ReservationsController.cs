using wayFinder.Services;

namespace wayFinder.Controllers
{
  public class ReservationsController
  {
    private readonly ReservationsService _rs;

    public ReservationsController(ReservationsService rs)
    {
      _rs = rs;
    }
  }
}