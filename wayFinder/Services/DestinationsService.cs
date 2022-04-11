using System;
using wayFinder.Models;
using wayFinder.Repositories;

namespace wayFinder.Services
{
  public class DestinationsService
  {
    private readonly DestinationsRepo _dr;

    public DestinationsService(DestinationsRepo dr)
    {
      _dr = dr;
    }

    internal Destination CreateDestination(Destination destData)
    {
      throw new NotImplementedException();
    }
  }
}