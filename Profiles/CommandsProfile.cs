//This file maps our Command Model to our DTOs
//You need to create a profile for each of your models, since we only have one model this will be the only profile for this application

using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //         Source -> Target
            CreateMap<Command, CommandReadDto>(); //This maps our Command model to our CommandReadDto (GET requests)
            CreateMap<CommandCreateDto, Command>(); //This maps our CommandCreateDto to our Command model (POST request)
            CreateMap<CommandUpdateDto, Command>(); 
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}