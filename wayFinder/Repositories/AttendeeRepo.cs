using System.Data;
using Dapper;
using wayFinder.Models;

namespace wayFinder.Repositories
{

  public class AttendeeRepo

  {
    private readonly IDbConnection _db;

    public AttendeeRepo(IDbConnection db)
    {
      _db = db;
    }

    internal Attendee Get(int id)
    {
      string sql = @"
      SELECT 
      *
      FROM
      attendees
      WHERE 
      id = @id;
      ";
      return _db.QueryFirstOrDefault<Attendee>(sql, new { id });
    }
    internal Attendee Get(int destinationId, string accountId)
    {
      string sql = @"
      SELECT
      *
      FROM 
      attendees
      WHERE
      destinationId = @destinationId AND accountId = @accountId;
      ";
      return _db.QueryFirstOrDefault<Attendee>(sql, new { destinationId, accountId });
    }

    internal Attendee Create(Attendee attendeeData)
    {
      string sql = @"
      INSERT INTO attendees
      (accountId, destinationId)
      VALUES
      (@AccountId, @DestinationId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, attendeeData);
      attendeeData.Id = id;
      return attendeeData;
    }



    internal void DeleteAttendee(int attendeeId)
    {
      string sql = @"
      DELETE FROM attendees
      WHERE
      id = @attendeeId
      LIMIT 1;
      ";
      _db.Execute(sql, new { attendeeId });
    }
  }
}