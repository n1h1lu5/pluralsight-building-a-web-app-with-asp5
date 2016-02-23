using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWolrd.Models;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if(await _userManager.FindByEmailAsync("sam.hastings@theworld.com") == null)
            {
                // Add the user
                var newUser = new WorldUser()
                {
                    UserName = "samhastings",
                    Email = "sam.hastings@theWorld.com"
                };

                await _userManager.CreateAsync(newUser, "password");
            }
            if(!_context.Trips.Any())
            {
                // Add new Data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "samhastings",
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