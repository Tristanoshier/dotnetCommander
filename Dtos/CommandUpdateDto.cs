//DTO stands for Data Transfer Object
//This file tells our application what is required to update a command in the database (PUT & PATCH request)

using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
         //What the command does. this can only be 250 characters long and is a required field
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }//ex: run .NET Core app

        //This is the command line that does the HowTo action. This field is required
        [Required]
        public string Line { get; set; } //ex: dotnet run

        //This is the platform that the command is for. 
        [Required]
        public string Platform { get; set; } //ex: .NET Core CLI

    }
}