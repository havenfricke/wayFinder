using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wayFinder.Models;
using wayFinder.Services;

namespace wayFinder.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReservationsController : ControllerBase
  {
    private readonly ReservationsService _rs;

    public ReservationsController(ReservationsService rs)
    {
      _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Reservation>> CreateReservation([FromBody] Reservation resrData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        resrData.CreatorId = userInfo.Id;
        Reservation resr = _rs.CreateReservation(resrData);
        return Created($"api/reservations/{resr.Id}", resr);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<string>> DeleteReservation(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _rs.DeleteReservation(id, userInfo);
        return Ok("Deletey Completey");
      }
      catch (System.Exception)
      {
        return BadRequest("e.Message");
      }
    }
  }
}