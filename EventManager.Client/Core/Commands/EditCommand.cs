using EventManager.Services;
using System;
using System.Linq;

namespace EventManager.Client.Core.Commands
{
    public class EditCommand : Command
    {
        public EditCommand(EventService eventService) : base(eventService)
        {
        }

        public override string Execute(string[] cmdParams)
        {
            if (cmdParams.Length != 5)
            {
                throw new InvalidOperationException("You haven't supplied the right amount of parameters.");
            }

            int id = 0;
            if (int.TryParse(cmdParams[0], out id))
            {
                return this.eventService.EditEventById(id, cmdParams.Skip(1).ToArray());
            }

            return this.eventService.EditEventByName(cmdParams[0], cmdParams.Skip(1).ToArray());
        }
    }
}
