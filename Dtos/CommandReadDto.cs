//DTO stands for Data Transfer Object 
//This file tells our application what to send back to the client when using a GET request
//We take out platfrom from our model since we dont want our users to see what platform the command is for.
//(Theres no reason that a client wouldnt be allowed to see the platform, this is just for demonstration purposes)

namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

    }
}