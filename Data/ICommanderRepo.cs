//This is our interface or contract for our application. This file holds a list of the methods that we are using in this application (GET, POST, PUT, PATCH, DELETE)
//An inteface is like a contract. You cant break the rules of this contract if youre implementing this interface in your other repositories. 

using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        //We need this method for our POST, PUT, PATCH, and, DELETE methods to work in the database
        bool SaveChanges();

        //GET
        IEnumerable<Command> GetAllCommands();

        //GET by id
        Command GetCommandById(int id);

        //POST
        void CreateCommand(Command cmd);

        //PUT AND PATCH
        void UpdateCommand(Command cmd);

        //DELETE
        void DeleteCommand(Command cmd);
    }
}