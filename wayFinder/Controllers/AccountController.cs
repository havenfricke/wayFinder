using System;
using System.Threading.Tasks;
using wayFinder.Models;
using wayFinder.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace wayFinder.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly DestinationsService _ds;

    public AccountController(AccountService accountService, DestinationsService ds)
    {
      _accountService = accountService;
      _ds = ds;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("destinations")]
    [Authorize]
    public async Task<ActionResult<List<AttendeeDestinationVM>>> GetDestinations()
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ds.GetUserDestinations(user.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}