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

        public static class EventsBasket 
        {
            public static string GetBasket(string baseuri, string basketId)
            {
                return $"{baseuri}/{basketId}";
            }

            public static string UpdateBasket(string baseuri)
            {
                return baseuri;
            }
            public static string CleanBasket(string baseuri, string basketid)
            {
                return $"{baseuri}/{basketid}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string GetOrders(string baseUri, string buyerId)
            {
                return $"{baseUri}/getorders?buyerId={buyerId}";
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
