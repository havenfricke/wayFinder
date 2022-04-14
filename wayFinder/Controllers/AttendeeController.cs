
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wayFinder.Models;
using wayFinder.Services;


namespace wayFinder.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class AttendeeController : ControllerBase
  {
    private readonly AttendeeService _atts;

    public AttendeeController(AttendeeService atts)
    {
      _atts = atts;
    }

    [HttpPost]

    public async Task<ActionResult<Attendee>> CreateAttendee([FromBody] Attendee attendeeData)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        attendeeData.AccountId = user.Id;
        Attendee created = _atts.CreateAttendee(attendeeData);
        return Ok(created);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }


    [HttpDelete]

    public async Task<ActionResult<string>> DeleteAttendee(int id)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        _atts.DeleteAttendee(id, user.Id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
