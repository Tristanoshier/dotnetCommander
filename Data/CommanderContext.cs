//This tutorial uses Microsoft SQL Server for the database but since I am on a mac, I decided to use a PostgreSQL database since its what im familiar with
//For my mac users, you are still able to use SQL Server if your implement it through docker. I will have a future repo that uses this.
//Anyone who also wants to use PostgreSQL for their server. The connection string looks like this "Server=<SERVER NAME>;Port=<PORT #>;Database=<DB NAME>;Username=<USERNAME;Password=<PASSWORD>"  
//The file that holds my connection string is in my gitignore since I dont want my information exposed

using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        //tells database to use the Command model 
        public DbSet<Command> Commands { get; set; }
    }
}