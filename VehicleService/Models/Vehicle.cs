using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleService.Models
{    public class Vehicle
    {
        public int Id { get; set; }
        [Range(1950, 2050)]
        public int Year { get; set; }

        [Required]
        public String Make { get; set; }
        [Required]
        public String Model { get; set; }

    }
}