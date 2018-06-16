using EventManager.Services;
using System;

namespace EventManager.Client.Core.Commands
{
    public class ListCommand : Command
    {
        public ListCommand(EventService eventService) : base(eventService)
        {
        }

        public override string Execute(string[] cmdParams)
        {
            if (cmdParams.Length != 0)
            {
                throw new InvalidOperationException("You haven't supplied the right amount of parameters.");
            }

            return this.eventService.ListAll();
        }
    }
}
