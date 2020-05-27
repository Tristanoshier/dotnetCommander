//This is a sample repository that is used in the tutorial before we connect to our database. 
//This file is not being used in the final product but I kept it in just in case I wanted to work with sample data in the future.

using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    //We are implementing our interface into our repository
    public class MockCommanderRepo : ICommanderRepo // this will throw you and error until you implement the methods in your ICommanderRepo. 
    {
        // to implement your methods use Cmd . on Mac (Ctrl . on Windows)

        //this method is not set up to work since at this point in the tutorial we have connected to the database
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        //this method is not set up to work since at this point in the tutorial we have connected to the database
        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        //This is all sample data and has nothing to do with the actual application

        public IEnumerable<Command> GetAllCommands()
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

        //this method is not set up to work since at this point in the tutorial we have connected to the database
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
        
        //this method is not set up to work since at this point in the tutorial we have connected to the database
        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    } 
}