using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class Apipaths
    {
        public static class EventsCatalog
        {
            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}Eventtypes";
            }
            public static string GetAllEventLocations(string baseUri)
            {
                return $"{baseUri}EventLocations";
            }
            public static string GetAllEvents(string baseUri, int page, int take, int? location, int? type)
            {
                var filterQs = "?";
                if (location.HasValue) { 
                    
                    filterQs = $"{filterQs}eventlocationId={location.Value.ToString()}&";
                }
                if (type.HasValue)
                {
                    filterQs = $"{filterQs}&eventTypeId={type.Value.ToString()}&";
                } 
                return $"{baseUri}Events{filterQs}pageIndex={page}&pageSize={take}";
            }
        }
    }
}
