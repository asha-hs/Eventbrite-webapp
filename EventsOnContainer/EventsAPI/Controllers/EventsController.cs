using EventsAPI.Data;
using EventsAPI.Domains;
using EventsAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsContext _context;
        private readonly IConfiguration _config;
        public EventsController(IConfiguration config, EventsContext context)
        {
            _context = context;
            _config = config;

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Events1(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
                .OrderByDescending(c => c.StartTime)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        private List<Event> ChangePictureUrl(List<Event> items)
        {
            items.ForEach(item =>
                item.PictureUrl = item.PictureUrl.Replace(
                    "http://externaleventsbaseurltobereplaced", _config["ExternalEventUrl"]));
            return items;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventsByPrice(
            [FromQuery] int price = 0,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 3
            )
        {
            var itemsCount = _context.Events.Where(c => c.Price == price).LongCountAsync();
            var items = await _context.Events.OrderByDescending(c => c.StartTime)
                .Where(c => c.Price == price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();


            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventsByLocation(
            [FromQuery] int locationId = 1,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 1
            )
        {
            var eventsCount = _context.Events.Where(c => c.Location.Id == locationId).LongCountAsync();
            var items = await _context.Events.OrderByDescending(c => c.StartTime)
                            .Where(c => c.Location.Id == locationId)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = eventsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventsByName(
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 5
           )
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
           

            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Eventtypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.Locations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery] int? eventTypeId,
            [FromQuery] int? eventlocationId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.Events;
            if (eventTypeId.HasValue)
            {
                query = query.Where(e => e.EventsTypeId == eventTypeId.Value);
            }
            if (eventlocationId.HasValue)
            {
                query = query.Where(e => e.LocationId == eventlocationId.Value);
            }

            var count = query.LongCountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = count.Result,

                Data = items
            };
            return Ok(model);

        }
    }
}
