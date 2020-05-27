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

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        //returns all commands from our database in a list
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        //return a command that matches the id requested 
        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}