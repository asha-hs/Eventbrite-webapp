using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;

        public object ApiPaths { get; private set; }

        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventCatalogUrl"]}/api/Events/";
            _client = client;

        }
        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = Apipaths.EventsCatalog.GetAllEventLocations(_baseUrl);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = location.Value<string>("id"),
                        Text = $"{ location.Value<string>("city")},{ location.Value<string>("state")}"
                    });
            }
            return items;
        }

        public async  Task<EventCatalog> GetEventsAsync(int page, int size, int? type, int? location)
        {
            var eventsURI = Apipaths.EventsCatalog.GetAllEvents(_baseUrl, page, size, location, type);
            var datastring = await _client.GetStringAsync(eventsURI);
            return JsonConvert.DeserializeObject<EventCatalog>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typesUri = Apipaths.EventsCatalog.GetAllEventTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    });
            }
            return items;
        }
    }
}
