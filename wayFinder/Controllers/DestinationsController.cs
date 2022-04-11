using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wayFinder.Models;
using wayFinder.Services;

namespace wayFinder.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DestinationsController : ControllerBase
  {
    private readonly DestinationsService _ds;
    private readonly ReservationsService _rs;

    public DestinationsController(DestinationsService ds, ReservationsService rs)
    {
      _ds = ds;
      _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Destination>> CreateDestination([FromBody] Destination destData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        destData.CreatorId = userInfo.Id;
        Destination dest = _ds.CreateDestination(destData);
        return Created($"api/destinations/{dest.Id}", dest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet]
    public ActionResult<List<Destination>> GetAllDestinations();


  }
}