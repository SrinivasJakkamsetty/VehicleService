using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleService.Models
{
    public class FilterCriteria
    {
        public int Year { get; set; }
        public String Make { get; set; }

        public String Model { get; set; }

    }
}