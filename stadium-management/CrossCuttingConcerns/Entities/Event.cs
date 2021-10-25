using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public Stage Stage { get; set; }
        public string Requirements { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SeatsAvailableStandard { get; set; }
        public int SeatsAvailablePlus { get; set; }
        public int BasePrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}