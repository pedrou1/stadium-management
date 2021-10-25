using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.Model
{
    public class Events
    {
        public static GetEventsOut GetEvents(GetEventsIn input)
        {
            return Persistence.Events.GetEvents(input);
        }

        public static GetEventTypesOut GetEventTypes()
        {
            return Persistence.Events.GetEventTypes();
        }

        public static AddEventOut AddEvent(Event input)
        {
            return Persistence.Events.AddEvent(input);
        }

        public static DeleteEventOut DeleteEvent(Event input)
        {
            return Persistence.Events.DeleteEvent(input);
        }

        public static GetEventByIdOut GetEventById(Event input)
        {
            return Persistence.Events.GetEventById(input);
        }

        public static UpdateEventOut UpdateEvent(Event input)
        {
            return Persistence.Events.UpdateEvent(input);
        }
    }
}