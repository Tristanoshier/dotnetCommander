using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
           var commands = new List<Command>
           {
               new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle and Pan"},
               new Command{Id=1, HowTo="Cut bread", Line="get a knife", Platform="Knife and chopping board"},
               new Command{Id=2, HowTo="make tea", Line="place teabag in cup", Platform="kettle and cup"}
           };

           return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle and Pan"};
        }
    } 
}