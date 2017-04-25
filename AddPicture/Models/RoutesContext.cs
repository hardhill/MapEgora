using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AddPicture.Models
{
    public class RoutesContext:DbContext
    {
        DbSet<Route> Routes { get; set; }
    }
}