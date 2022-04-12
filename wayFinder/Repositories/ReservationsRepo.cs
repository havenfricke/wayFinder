using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using wayFinder.Models;

public class ReservationsRepo
{
  private readonly IDbConnection _db;

  public ReservationsRepo(IDbConnection db)
  {
    _db = db;
  }

  internal List<Reservation> GetAllResrByDestId(int id)
  {
    string sql = @"
    SELECT
    *
    FROM
    reservations
    WHERE
    destinationId = @id;
    ";
    return _db.Query<Reservation>(sql, new { id }).ToList();
  }

  internal Reservation CreateReservation(Reservation resrData)
  {
    string sql = @"
    INSERT INTO reservations
    (title, type, confirmation, address, date, notes, cost)
    VALUES
    (@Title, @Type, @Confirmation, @ Address, @Date, @Notes, @Cost);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, resrData);
    resrData.Id = id;
    return resrData;
  }

  internal Reservation GetReservationById(int id)
  {
    throw new NotImplementedException();
  }

  internal void DeleteReservation(int id)
  {
    string sql = @"
    DELETE FROM 
    reservations
    WHERE
    id = @id
    LIMIT
    1;
    ";
    _db.Execute(sql, new { id });
  }
}
