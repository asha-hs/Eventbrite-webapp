using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int LocationId { get; set; }
        public int EventsTypeId { get; set; }
        public int EventCreaterId { get; set; }

        public string Location { get; set; }
        public string  EventsType { get; set; }

        public string  EventsCreater { get; set; }

    }
}
