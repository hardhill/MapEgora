using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddPicture.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageMap { get; set; }
    }
}