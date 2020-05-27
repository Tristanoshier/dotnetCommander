using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    //We are implementing our interface into our repository
    public class SqlCommanderRepo : ICommanderRepo // this will throw you and error until you implement the methods in your ICommanderRepo. 
    {
        // to implement your methods use Cmd . on Mac (Ctrl . on Windows)
        //generate readonly field
        private readonly CommanderContext _context;

        //we store an instance of CommanderContext in a varaiable so we can interact with our database
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        // (POST) allows user to create a command in the database
        public void CreateCommand(Command cmd)
        {
            //This checks if all fields are entered, if not it will throw an error saying you havent filled out a specific field
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }
        
        // (DELETE)
        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        // (GET) returns all commands from our database in a list
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        // (GET) return a command that matches the id requested 
        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        //This method makes sure any POST, PUT, PATCH, and DELELTE methods get applied to the database
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // (PUT & PATCH)
        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}