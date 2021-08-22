using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _service;
        public EventsController ( IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? typesFilterApplied, int? locationFilterApplied )
        {
            var itemsOnPage = 10;

            var eventscatalog = await _service.GetEventsAsync(page ?? 0, itemsOnPage, typesFilterApplied, locationFilterApplied);

            var vm = new EventCatalogIndexViewModel
            {
                Locations = await _service.GetLocationsAsync(),
                Types = await _service.GetTypesAsync(),
                CatalogItems = eventscatalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    TotalItems = eventscatalog.Count,
                    ItemsPerPage = eventscatalog.PageSize,
                    ActualPage = page ?? 0,
                    TotalPages = (int)Math.Ceiling((decimal)eventscatalog.Count / itemsOnPage)
                },
                LocationFilterApplied = locationFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };


            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}
