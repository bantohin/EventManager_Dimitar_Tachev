using EventManager.Data;
using EventManager.Models;
using System;
using System.Linq;
using System.Text;

namespace EventManager.Services
{
    public class EventService
    {
        private readonly EventManagerContext db = new EventManagerContext();

        public bool EventExists(string name)
        {
            if (this.db.Events.Count(e => e.Name.ToLower() == name.ToLower()) > 0)
            {
                return true;
            }

            return false;
        }

        public string CreateEvent(string[] eventParams)
        {
            Event newEvent;
            try
            {
                newEvent = new Event()
                {
                    Name = eventParams[0],
                    Location = eventParams[1],
                    StartDateTime = DateTime.Parse(eventParams[2]),
                    EndDateTime = DateTime.Parse(eventParams[3])
                };

            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid date format. Please enter the date as shown in the start message.");
            }

            if (newEvent.StartDateTime > newEvent.EndDateTime)
            {
                throw new InvalidOperationException("You cannot create an event with an end date earlier than the start date.");
            }

            this.db.Events.Add(newEvent);
            this.db.SaveChanges();

            return $"Event {newEvent.Name} at/in {newEvent.Location} from {newEvent.StartDateTime.ToShortDateString()} to {newEvent.EndDateTime.ToShortDateString()} was successfully created.";
        }

        public string DeleteEventById(int id)
        {
            Event eventToDelete = this.db.Events.FirstOrDefault(e => e.Id == id);

            return this.DeleteEvent(eventToDelete);
        }

        public string DeleteEventByName(string name)
        {
            Event eventToDelete = this.db.Events.FirstOrDefault(e => e.Name == name);

            return this.DeleteEvent(eventToDelete);
        }

        public string ListAll()
        {
            Event[] events = this.db.Events.ToArray();
            
            if (events.Length == 0)
            {
                return $"There are currently no registered events.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---Current Events---");

            foreach (Event @event in events)
            {
                sb.AppendLine($"{@event.Name} at/in {@event.Location} from {@event.StartDateTime.ToShortDateString()} to {@event.EndDateTime.ToShortDateString()}");
            }

            sb.AppendLine("--------------------");
            return sb.ToString();
        }

        public string EditEventById(int id, string[] eventParams)
        {
            Event eventToEdit = this.db.Events.FirstOrDefault(e => e.Id == id);

            return this.EditEvent(eventToEdit, eventParams);
        }

        public string EditEventByName(string name, string[] eventParams)
        {
            Event eventToEdit = this.db.Events.FirstOrDefault(e => e.Name == name);

            return this.EditEvent(eventToEdit, eventParams);
        }

        private string EditEvent(Event eventToEdit, string[] eventParams)
        {
            if (eventToEdit == null)
            {
                throw new InvalidOperationException("No such event exists.");
            }

            try
            {
                eventToEdit.Name = eventParams[0];
                eventToEdit.Location = eventParams[1];
                eventToEdit.StartDateTime = DateTime.Parse(eventParams[2]);
                eventToEdit.EndDateTime = DateTime.Parse(eventParams[3]);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid date format. Please enter the date as shown in the start message.");
            }

            if (eventToEdit.StartDateTime > eventToEdit.EndDateTime)
            {
                throw new InvalidOperationException("You cannot create an event with an end date earlier than the start date.");
            }

            this.db.SaveChanges();

            return $"You have successfully edited the event.";
        }

        private string DeleteEvent(Event eventToDelete)
        {
            if (eventToDelete == null)
            {
                throw new InvalidOperationException("No such event exists");
            }

            this.db.Events.Remove(eventToDelete);
            this.db.SaveChanges();

            return $"The event was successfully deleted.";
        }
    }
}
