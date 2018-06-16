using EventManager.Services;

namespace EventManager.Client.Core.Commands
{
    public abstract class Command
    {
        protected readonly EventService eventService;

        public Command(EventService eventService)
        {
            this.eventService = eventService;
        }

        public abstract string Execute(string[] cmdParams);
    }
}
