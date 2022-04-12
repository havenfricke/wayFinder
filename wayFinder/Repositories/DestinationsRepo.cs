


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
    string sql = @"
    INSERT INTO
    destinations (name)
    VALUES
    (@Name);
    SELECT LAST_INSERT_ID();
    ";
    _db.ExecuteScalar(sql, destData);
    return destData;
  }

  internal List<Destination> GetAllDestinations(string Id)
  {
    string sql = @"
    SELECT
    *
    FROM 
    destinations
    WHERE
    creatorId = @Id;
    ";
    return _db.Query<Destination>(sql, new { Id }).ToList();
  }


  internal Destination GetDestinationById(int id)
  {
    throw new NotImplementedException();
  }

  internal void EditDestination(Destination original)
  {
    string sql = @"
    UPDATE
    destinations
    SET
    name = @name
    WHERE
    id = @Id;
    ";
    _db.Execute(sql, original);
  }

  internal void DeleteDestination(int id)
  {
    string sql = @"
    DELETE FROM
    destinations
    WHERE
    id = @id
    LIMIT
    1;
    ";
    _db.Execute(sql, new { id });
  }


}
