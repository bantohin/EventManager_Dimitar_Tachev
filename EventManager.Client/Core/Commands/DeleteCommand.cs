using EventManager.Services;
using System;

namespace EventManager.Client.Core.Commands
{
    public class DeleteCommand : Command
    {
        public DeleteCommand(EventService eventService) : base(eventService)
        {
        }

        public override string Execute(string[] cmdParams)
        {
            if (cmdParams.Length != 1)
            {
                throw new InvalidOperationException("You haven't supplied the right amount of parameters.");
            }

            int id = 0;
            if (int.TryParse(cmdParams[0], out id))
            {
                return this.eventService.DeleteEventById(id);
            }

            string name = cmdParams[0].ToString();

            return this.eventService.DeleteEventByName(name);
        }
    }
}
