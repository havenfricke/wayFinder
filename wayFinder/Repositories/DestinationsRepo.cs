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
    destinations (name, creatorId)
    VALUES
    (@Name, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, destData);
    destData.Id = id;
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
    string sql = @"
    SELECT
    *
    FROM
    destinations
    WHERE
    id = @id;
    ";
    return _db.QueryFirstOrDefault<Destination>(sql, new { id });
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

  internal List<AttendeeDestinationVM> GetbyAttendeeAccountId(string userId)
  {
    string sql = @"
    SELECT
    acc.*,
    d.*,
    att.id AS AttendeeId
    FROM attendees att
    JOIN destinations d ON d.id = att.destinationId
    JOIN accounts acc ON acc.id = d.creatorId
    WHERE att.accountId = @userId; 
    ";
    return _db.Query<Account, AttendeeDestinationVM, AttendeeDestinationVM>(sql, (acc, advm) =>
    {
      advm.TripHost = acc;
      return advm;
    }, new { userId }).ToList();
  }
}
