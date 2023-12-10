using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class EventsController : BaseApiController
{
  private readonly DataContext _context;
  public EventsController(DataContext context)
  {
    _context = context;
  }

  [HttpGet]
  // public ActionResult<IEnumerable<AppEvent>> GetEvents()
  // {
  //       var events = _context.Events.ToList();

  //       return events;
  // }
  public async Task<ActionResult<IEnumerable<AppEvent>>> GetEvents()
  {
        var abc = 1;
        var events = await _context.Events.ToListAsync();

        return events;
  }

  [HttpGet("{id}")] //api/events/2
  public async Task<ActionResult<AppEvent?>> GetEvent(int id)
  {
    return await _context.Events.FindAsync(id);
  }


}
