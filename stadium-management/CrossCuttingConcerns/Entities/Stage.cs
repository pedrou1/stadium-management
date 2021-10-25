using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class Stage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CapacitySeatsStandard { get; set; }
        public int CapacitySeatsPlus { get; set; }
        public string Image { get; set; }
    }
}