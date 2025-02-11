using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entities;

namespace WebApplication1.Model
{
    public class EventModel
    {
        public int EventId { get; set; }
        public int CalendarId { get; set; }

        public string EventName { get; set; } = null!;

        public int EventTypeId { get; set; }

        public int EventStatusId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string? ResponsiblePersons { get; set; }

        public string? Description { get; set; }

        public EventModel(Event ev)
        {
            EventId = ev.EventId;
            CalendarId = ev.CalendarId;
            EventName = ev.EventName;
            EventTypeId = ev.EventTypeId;
            EventStatusId = ev.EventStatusId;
            StartDate = ev.StartDate;
            EndDate = ev.EndDate;
            ResponsiblePersons = ev.ResponsiblePersons;
            Description = ev.Description;
        }
    }
}
