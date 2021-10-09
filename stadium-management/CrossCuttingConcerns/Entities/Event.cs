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
        public string Requirements { get; set; }
        public int Price { get; set; }
        public string Logo { get; set; }
        public bool IsDeleted { get; set; }
    }
}