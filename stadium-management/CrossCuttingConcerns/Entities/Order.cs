using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Event Event { get; set; }
    }
}