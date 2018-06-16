using EventManager.Client.Core.Commands;
using EventManager.Services;
using System;
using System.Linq;
using System.Reflection;

namespace EventManager.Client.Core
{
    public class CommandDispatcher
    {
        private readonly EventService eventService;

        public CommandDispatcher(EventService eventService)
        {
            this.eventService = eventService;
        }

        public string ExecuteCommand(string[] cmdParams)
        {
            string name = cmdParams[0];
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type cmdType = null;
            foreach (Assembly assembly in assemblies)
            {
                cmdType = assembly.GetType("EventManager.Client.Core.Commands." + name + "Command");

                if (cmdType != null)
                    break;
            }

            if (cmdType == null)
            {
                throw new InvalidOperationException("No such command exists.");
            }

            var constructor = cmdType.GetConstructor(new Type[] { typeof(EventService) });
            Command command = (Command)constructor.Invoke(new object[] { eventService });

            return command.Execute(cmdParams.Skip(1).ToArray());
        }
    }
}
