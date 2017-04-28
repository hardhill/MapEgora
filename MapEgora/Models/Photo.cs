﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapEgora.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required()]
        public DateTime Photocreated { get; set; }
        public string Description { get; set; }
        [Required()]
        public string PhotoName { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}