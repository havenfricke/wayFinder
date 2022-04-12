using System.Data;
using Dapper;
using wayFinder.Models;

namespace wayFinder.Repositories
{
  public class AttendeesRepo
  {
    private readonly IDbConnection _db;

    public AttendeesRepo(IDbConnection db)
    {
      _db = db;
    }

    internal Attendee CreateAttendee(Attendee attendeeData)
    {
      string sql = @"
      INSERT INTO attendees
      (destinationId)
      VALUES
      (@DestinationId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, attendeeData);
      attendeeData.Id = id;
      return attendeeData;
    }
  }
}