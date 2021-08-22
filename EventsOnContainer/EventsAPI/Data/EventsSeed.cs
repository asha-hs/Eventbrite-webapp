using EventsAPI.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Data
{
    public static class EventsSeed
    {
        public static void Seed(EventsContext eventsContext)
        {
            eventsContext.Database.Migrate();

            if(!eventsContext.EventHosts.Any())
            {
                eventsContext.EventHosts.AddRange(GetEventsHosts());
                eventsContext.SaveChanges();
            }
            if (!eventsContext.EventTypes.Any())
            {
                eventsContext.EventTypes.AddRange(GetEventsType());
                eventsContext.SaveChanges();
            }
            if (!eventsContext.Locations.Any())
            {
                eventsContext.Locations.AddRange(GetEventsLocations());
                eventsContext.SaveChanges();
            }
            if (!eventsContext.Events.Any())
            {
                eventsContext.Events.AddRange(GetEvents());
                eventsContext.SaveChanges();
            }
        }

        private static IEnumerable<Location> GetEventsLocations()
        {
            return new List<Location>
            {
                new Location
                {
                    Lat = 47.6739M,
                    Lon =  -122.1215M,
                    City = "Fairmont",
                    State = "WV"
                },
                new Location
                {
                    Lat = 47.6739M,
                    Lon =  -122.1215M,
                    City = "Columbus",
                    State = "OH"
                },
                new Location
                {
                    Lat = 47.6739M,
                    Lon =  -122.1215M,
                    City = "Heath",
                    State = "OH"
                },
                new Location
                {
                    Lat = 47.6739M,
                    Lon =  -122.1215M,
                    City = "Wheeling",
                    State = "WV"
                },
                new Location
                {
                    Lat = 47.6739M,
                    Lon =  -122.1215M,
                    City = "Redmond",
                    State = "WA"
                },
                new Location
                {
                    Lat = 47.7623M,
                    Lon = -122.2054M,
                    City = "Bothell",
                    State = "WA"
                },
                new Location
                {
                    Lat = 47.6814M,
                    Lon = -122.2087M,
                    City = "Kirkland",
                    State = "WA"
                },
                new Location
                {
                    Lat = 47.6103M,
                    Lon = -122.2006M,
                    City = "Bellevue",
                    State = "WA"
                },
                new Location
                {
                    Lat = 39.2974M,
                    Lon = -78.4342M,
                    City = "Capon Bridge",
                    State = "WV"
                },
                new Location
                {
                    Lat = 37.7775M,
                    Lon = -81.1748M,
                    City = "Beckley",
                    State = "WV"
                },
                new Location
                {
                    Lat = 39.3321M,
                    Lon = -77.9048M,
                    City = "Kearneysville",
                    State = "WV"
                },
                new Location
                {
                    Lat = 38.3510M,
                    Lon = -81.6278M,
                    City = "Charleston",
                    State = "WV"
                },
                new Location
                {
                    Lat = 37.3696M,
                    Lon = -81.0958M,
                    City = "Princeton",
                    State = "WV"
                },
                new Location
                {
                    Lat = 61.21807M,
                    Lon = -149.90029M,
                    City = "Anchorage",
                    State = "AK"
                },
                new Location
                {
                    Lat = 47.60866M,
                    Lon = -122.34520M,
                    City = "Seattle",
                    State = "WA"
                }
            };
        }

        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event
                {
                    EventsTypeId = 5,
                    EventCreaterId = 21,
                    LocationId = 15,
                    Description = "Mother Son Dance for boys Pre-K through 7th grade.",
                    Name = "Mother Son Dance",
                    Price = 20.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/25",
                    StartTime = new DateTime(2021,08,20,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,8,20,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 5,
                    EventCreaterId = 21,
                    LocationId = 15,
                    Description = "Father Daughter Dance for girls Pre-K through 12th grade.",
                    Name = "Father Daughter Dance",
                    Price = 20.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/24",
                    StartTime = new DateTime(2021,08,21,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,8,21,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 5,
                    EventCreaterId = 20,
                    LocationId = 14,
                    Description = "Join CGB and the Empower Our Youth Foundation by volunteering for their Dare 2 Be Different Anti-Bullying Fashion Show",
                    Name = "Volunteer for Dare 2 Be Different Anti-Bullying Fashion Show - 8/21/21",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/23",
                    StartTime = new DateTime(2021,09,21,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,9,21,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 5,
                    EventCreaterId = 19,
                    LocationId = 13,
                    Description = "Pony Express is a recreational horseback riding program for children with disabilities. Riding is an excellent form of recreation.",
                    Name = "Pony Express Fall 2021",
                    Price = 25.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/22",
                    StartTime = new DateTime(2021,09,14,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,10,19,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 5,
                    EventCreaterId = 18,
                    LocationId = 12,
                    Description = "Disney movie Frozen is brought to life on the CPAC stage. Featuring over 40 local talented youth. The coolest show this summer!",
                    Name = "Frozen Jr",
                    Price = 10.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/21",
                    StartTime = new DateTime(2021,08,22,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,15,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 3,
                    EventCreaterId = 1,
                    LocationId = 1,
                    Description = "Seattle Tech Career Fair:Exclusive Tech Hiring Event-New",
                    Name = "Tech Career Fair",
                    Price = 50.9M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/1",
                    StartTime = new DateTime(2021,08,15,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,15,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 3,
                    EventCreaterId = 2,
                    LocationId = 1,
                    Description = "Develop a Successful GreenTech / CleanTech Startup Business Today",
                    Name = "GreenTech / CleanTech",
                    Price = 50.9M,
                    PictureUrl="http://externaleventsbaseurltobereplaced/api/pic/2",
                    StartTime = new DateTime(2021,08,16,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,16,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 3,
                    EventCreaterId = 3,
                    LocationId = 10,
                    Description = "Thinkful Webinar | Getting Started in Tech",
                    Name = "Getting Started in Tech",
                    Price=50.9M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/3",
                    StartTime = new DateTime(2021,08,17,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,17,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 3,
                    EventCreaterId = 2,
                    LocationId = 9,
                    Description = "Develop a Successful Healthcare Tech Startup Business Hackathon | Healthcare Tech Entrepreneurship Workshop | Medtech Entrepreneur Training",
                    Name = "Healthcare Tech Startup Business",
                    Price = 50.9M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/4",
                    StartTime = new DateTime(2021,08,18,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,18,6,10,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 3,
                    EventCreaterId = 2,
                    LocationId = 2,
                    Description = "Develop a Successful Food Tech Startup Business Hackathon | Startup Hackathon | Entrepreneur Hackathon | Entrepreneurship Hackathon",
                    Name = "Food Tech Startup Business",
                    Price = 50.9M,PictureUrl="http://externaleventsbaseurltobereplaced/api/pic/5",
                    StartTime = new DateTime(2021,08,19,5,10,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,19,6,10,20,DateTimeKind.Local),
                },


                new Event
                {
                    EventsTypeId = 2,
                    EventCreaterId = 6,
                    LocationId = 7,
                    Description = "Join us at The River House in Capon Bridge, WV every Saturday from 12-3 for a free drop in art activity. All materials provided!",
                    Name = "Art for All- Free Art Activity for all ages!",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/6",
                    StartTime = new DateTime(2021,07,31,12,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,07,31,3,00,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 2,
                    EventCreaterId = 7,
                    LocationId = 6,
                    Description = "The Ecstasy of Gold is Beckley Art Center's newest solo exhibition featuring the collage artistry of artist, Psychoflauge.",
                    Name = "The Ecstasy of Gold | Exhibition Opening Reception",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/7",
                    StartTime = new DateTime(2021,08,6,6,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,6,7,30,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 2,
                    EventCreaterId = 8,
                    LocationId = 5,
                    Description = "Join your friends at a top judged festival in America! 45th Annual Fall Mountain Heritage Arts & Crafts Festival 2021, FREE WV Wine Tastings",
                    Name = "45th Annual Fall Mountain Heritage Arts & Crafts Festival",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/8",
                    StartTime = new DateTime(2021,09,24,10,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,09,26,5,00,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 2,
                    EventCreaterId = 9,
                    LocationId = 4,
                    Description = "FIGURE DRAWING @ Studio 3D July - August Session Starting July 29th we're hosting 4 Figure Drawing sessions!",
                    Name = "Figure Drawing July-August Session",
                    Price = 40.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/9",
                    StartTime = new DateTime(2021,07,27,6,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,27,9,00,20,DateTimeKind.Local),
                },
                new Event
                {
                    EventsTypeId = 2,
                    EventCreaterId = 10,
                    LocationId = 3,
                    Description = "We will be painting a Sunflower in the style of Van Gogh. All materials are included to paint your masterpiece. No experience necessary, our",
                    Name = "Peak Of The Bloom Sunflower Painting Class",
                    Price = 29.99M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/10",
                    StartTime = new DateTime(2021,08,14,5,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,14,8,00,20,DateTimeKind.Local),
                },

                new Event
                {
                    Description = "Cooking Class ~ Homemade Tomato Risotto with Burrata and Basil ",
                    Name = "Tomato Risotto with Burrata and Basil",
                    Price = 5,
                    StartTime = new DateTime(2021, 9, 18, 16, 0, 0, DateTimeKind.Local),
                    EndTime = new DateTime(2021, 9, 18, 16, 0, 0, DateTimeKind.Local),
                    EventCreaterId = 6,
                    EventsTypeId = 1,
                    LocationId = 1,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/11"
                },
                new Event
                {
                    Description = "Cooking Class ~ Jambalaya with Saffron Aioli! Presented with our Buddies at SCANPAN & GLOBAL Cutlery",
                    Name = "Jambalaya with Saffron Aioli",
                    Price = 3,
                    StartTime = new DateTime(2021, 9, 9, 16, 0, 0, DateTimeKind.Local),
                    EndTime = new DateTime(2021, 9, 9, 16, 0, 0, DateTimeKind.Local),
                    EventCreaterId = 6,
                    EventsTypeId = 1,
                    LocationId = 1,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/12"
                },
                new Event
                {
                    Description = "No time in the morning? Learn how to whip up nourishing smoothie bowls in no time flat.",
                    Name = "Smoothie Bowls and Beyond",
                    Price = 5,
                    StartTime = new DateTime(2021, 9, 15, 16, 0, 0, DateTimeKind.Local),
                    EndTime = new DateTime(2021, 9, 15, 16, 0, 0, DateTimeKind.Local),
                    EventCreaterId = 17,
                    EventsTypeId = 1,
                    LocationId = 1,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/13"
                },
                new Event
                {
                    Description =" More and more people are interested in vegan/plant-based eating. Some are just curious, some want to get their feet wet, and some are ready to come to the V-side - ",
                    Name = "Vegan For Beginners",
                    Price = 3,
                    StartTime = new DateTime(2021, 9, 18, 17,0,0,DateTimeKind.Local),
                    EndTime = new DateTime(2021, 9, 18, 18,0,0,DateTimeKind.Local),
                    EventCreaterId = 7,
                    EventsTypeId = 1,
                    LocationId = 1,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/14"
                },
                new Event
                {
                    Description ="Homemade Free Cooking Class ~ Cheese Soufflé and Summer Salad with Green Goddess Dressing, with our Buddies at Cabot Cheese ",
                    Name = "Cheese Soufflé and Summer Salad",
                    Price = 0,
                    StartTime = new DateTime(2021, 9, 28, 16,0,0,DateTimeKind.Local),
                    EndTime = new DateTime(2021, 9, 28, 17,0,0,DateTimeKind.Local),
                    EventCreaterId = 6,
                    EventsTypeId = 1,
                    LocationId = 1,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/15"
                },
                new Event
                {
                    EventsTypeId = 4,
                    EventCreaterId =13,
                    LocationId = 2,
                    Description = "Discover the power of your breath to relieve stress, ease anxiety and calm your mind in a free LIVE and interactive session.",
                    Name = "Beyond Breath - An Introduction to SKY Breath Meditation-Anchorage",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/18",
                    StartTime = new DateTime(2021,07,31,3,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,07,31,4,15,20,DateTimeKind.Local),
                },
                 new Event
                {
                     EventsTypeId = 4,
                    EventCreaterId =13,
                    LocationId = 1,
                    Description = "Discover the power of your breath to relieve stress, ease anxiety and calm your mind in a free LIVE and interactive session.",
                    Name = "Beyond Breath - An Introduction to SKY Breath Meditation - Seattle",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/18",
                    StartTime = new DateTime(2021,07,31,4,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,07,31,5,00,20,DateTimeKind.Local),

                },

                  new Event
                {
                    EventsTypeId = 4,
                    EventCreaterId = 14,
                    LocationId = 8,
                    Description = "Pranayama △ Joy of Breathing",
                    Name = "Free Online Breathwork Class. Unlock the benefits of Joy of Breathing. Awaken a conscious connection with your body, mind, heart and spirit.",
                    Price = 0.0M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/17",
                    StartTime = new DateTime(2021,08,04,10,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,04,10,30,20,DateTimeKind.Local),
                },

                   new Event
                {
                    EventsTypeId = 4,
                    EventCreaterId = 15,
                    LocationId = 1,
                    Description = "Zumba® with Daniel Santos: In-Person and Virtual",
                    Name = "Zumba® fuses hypnotic Latin rhythms and easy-to-follow moves to create a one-of-a-kind fitness program.",
                    Price = 15.50M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/19",
                    StartTime = new DateTime(2021,08,12,10,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,12,11,00,20,DateTimeKind.Local),
                },
                    new Event
                {
                    EventsTypeId = 4,
                    EventCreaterId =16,
                    LocationId = 1,
                    Description = "A workout for the entire family! Seattle Dance Fitness will be guiding you through an easy fun dance workout that'll have you making special fun memories! No need for any dance experience!",
                    Name = "DropSound Family Dance Class",
                    Price = 20.99M,
                    PictureUrl = "http://externaleventsbaseurltobereplaced/api/pic/20",
                    StartTime = new DateTime(2021,08,07,9,00,20,DateTimeKind.Local),
                    EndTime = new DateTime(2021,08,07,10,00,20,DateTimeKind.Local),
                },

            };
        }

        private static IEnumerable<EventsType> GetEventsType()
        {
            return new List<EventsType>
            {
                new EventsType
                {
                    Type="For Kids"
                },
                new EventsType
                {
                    Type = "Fittness&Health"
                },
                new EventsType
                {
                    Type = "Technology"
                },
                new EventsType
                {
                    Type = "Art"
                },
                new EventsType
                {
                    Type = "Food&Drink"
                }
            };
        }

        private static IEnumerable<EventsHost> GetEventsHosts()
        {
            return new List<EventsHost>
            {
                new EventsHost
                {
                    Creater = "Crystalline Events"
                },
                new EventsHost
                {
                    Creater = "Columbus Gives Back"
                },
                new EventsHost
                {
                    Creater = "Licking/Knox Goodwill Industries, Inc."
                },
                new EventsHost
                {
                    Creater = "Cambridge Performing Arts Centre"
                },
                new EventsHost
                {
                    Creater = "Tech Career Fair"
                },
                new EventsHost
                {
                    Creater = "Atechup.com"
                },
                new EventsHost
                {
                    Creater = "Thinkful Seattle"
                },
                new EventsHost
                {
                    Creater = "Women Hack"
                },
                new EventsHost
                {
                    Creater = " AnalyticsWEEK"
                },
                new EventsHost
                {
                    Creater = "Nola Ro"
                },
                new EventsHost
                {
                    Creater = "Homemade Events"
                },
                new EventsHost
                {
                    Creater = "The River House"
                },
                new EventsHost
                {
                    Creater = "Beckley Art Center"
                },
                new EventsHost
                {
                    Creater = "Jefferson County Chamber of Commerce, Inc."
                },
                new EventsHost
                {
                    Creater = "Tamarack Foundation for the Arts"
                },
                new EventsHost
                {
                    Creater = "The Bronze Look, LLC"
                },
                new EventsHost
                {
                    Creater = "The Art of Living Foundation"
                },
                new EventsHost
                {
                    Creater = "Soul Dimension"
                },
                new EventsHost
                {
                    Creater = "Bahia In Motion"
                },
                new EventsHost
                {
                    Creater = "SweatNET Seattle & Pier 62"
                },
                new EventsHost
                {
                    Creater = "Basics Market"
                }
            };
        }
    }
}
