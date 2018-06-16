using EventManager.Services;
using System;

namespace EventManager.Client.Core.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(EventService eventService) : base(eventService)
        {
        }

        public override string Execute(string[] cmdParams)
        {
            if (cmdParams.Length != 4)
            {
                throw new InvalidOperationException("You haven't supplied the right amount of parameters.");
            }

            string name = cmdParams[0];
            if (this.eventService.EventExists(name))
            {
                throw new InvalidOperationException("An event with the given name already exists.");
            }

            return this.eventService.CreateEvent(cmdParams);
        }
    }
}
