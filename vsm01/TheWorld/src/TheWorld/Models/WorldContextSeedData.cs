using System;
using System.Collections.Generic;
using System.Linq;
using TheWolrd.Models;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if(!_context.Trips.Any())
            {
                // Add new Data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop()
                        {
                            Name = "NY",
                            Arrival = new DateTime(),
                            Latitude = 12323412354,
                            Longitude = 123243531245
                        }
                    }
                };

                _context.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                _context.SaveChanges();
            }
        }
    }
}