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
  public class AttendeesController : ControllerBase
  {
    private readonly AttendeesService _atts;

    public AttendeesController(AttendeesService atts)
    {
      _atts = atts;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<DestinationVM>> CreateAttendee([FromBody] Attendee attendeeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        attendeeData.Account = userInfo;
        DestinationVM atten = _atts.Create(attendeeData);
        return Created($"api/attendees/{atten.Id}", atten);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}