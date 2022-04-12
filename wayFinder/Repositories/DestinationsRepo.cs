


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using wayFinder.Models;

public class DestinationsRepo
{
  private readonly IDbConnection _db;

  public DestinationsRepo(IDbConnection db)
  {
    _db = db;
  }

  internal Destination CreateDestination(Destination destData)
  {
    throw new NotImplementedException();
  }

  internal List<Destination> GetAllDestinations(Account user)
  {
    string sql = @$"
    SELECT
    *
    FROM 
    destinations;
    WHERE
    creatorId = {user.Id}
    ";
    return _db.Query<Destination>(sql).ToList();
  }


  internal Destination GetDestinationById(int id)
  {
    throw new NotImplementedException();
  }

  internal void EditDestination(Destination original)
  {
    throw new NotImplementedException();
  }

  internal void DeleteDestination(int id)
  {
    throw new NotImplementedException();
  }


}
