using System;
using System.Collections.Generic;
using wayFinder.Models;

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
      return _dr.CreateDestination(destData);
    }

    internal List<Destination> GetAllDestinations(Account user)
    {
      return _dr.GetAllDestinations(user.Id);
    }


    internal void DeleteDestination(int id, Account userInfo)
    {
      Destination dest = _dr.GetDestinationById(id);
      if (dest.CreatorId == userInfo.Id)
      {
        _dr.DeleteDestination(id);
      }
      else
      {
        throw new Exception("Not yours to delete");
      }
    }

    internal Destination EditDestination(int id, Destination destData, Account userInfo)
    {
      Destination dest = _dr.GetDestinationById(id);
      if (dest.CreatorId == userInfo.Id)
      {
        Destination original = _dr.GetDestinationById(id);
        original.Name = destData.Name ?? original.Name;
        _dr.EditDestination(original);
        return original;
      }
      else
      {
        throw new Exception("Not yours to edit");
      }
    }

  }
}