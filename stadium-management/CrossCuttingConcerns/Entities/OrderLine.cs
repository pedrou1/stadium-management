using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public int Cost { get; set; }
        public int SeatsStandard { get; set; }
        public int SeatsPlus { get; set; }
    }
}