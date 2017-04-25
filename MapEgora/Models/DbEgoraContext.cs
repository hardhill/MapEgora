using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MapEgora.Models
{
    public class DbEgoraContext:DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}