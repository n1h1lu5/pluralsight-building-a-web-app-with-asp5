using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TheWolrd.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}