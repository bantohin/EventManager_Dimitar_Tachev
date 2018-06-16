using EventManager.Client.Core;
using EventManager.Data;
using EventManager.Services;
using System;
using System.Text;

namespace EventManager.Client
{
    class StartUp
    {
        private static readonly EventManagerContext db = new EventManagerContext();

        static void Main(string[] args)
        {
            InitDatabase();
            PrintStartMessage();
            EventService eventService = new EventService();
            CommandDispatcher commandDispatcher = new CommandDispatcher(eventService);
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }

        private static void InitDatabase()
        {
            db.Database.EnsureCreated();
        }

        private static void PrintStartMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dimitar Tachev's Event Manager.");
            sb.AppendLine("Valid commands and their valid parameters:");
            sb.AppendLine("----------");
            sb.AppendLine("Create <Name> <Location> <Start Date> <End Date>");
            sb.AppendLine("Edit <Id/Name> <Name> <Location> <Start Date> <End Date>");
            sb.AppendLine("Delete <Id/Name>");
            sb.AppendLine("List");
            sb.AppendLine("----------");
            sb.AppendLine("All commands are case-sensitive!");
            Console.WriteLine(sb);
        }
    }
}
