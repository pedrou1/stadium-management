using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.OutMethods
{
    public class GetEventsOut : BaseMethodOut
    {
        public List<Event> Events { get; set; }
        public int TotalRows { get; set; }
    }
}