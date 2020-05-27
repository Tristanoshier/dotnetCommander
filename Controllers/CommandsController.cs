// This is the only controller in our application. This handles all of our CRUD method routes and the actions they will perform.

using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using System.Collections.Generic;
using Commander.Data;
using AutoMapper;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers 
{
    [Route("api/commands")] //This will be our base route for our api endpoints
    [ApiController] //This allows us to use Http methods
    public class CommandsController : ControllerBase //We inherit from this base class since our application doesnt have a view. We could inherit from Controller if we had a view
    {
        private readonly ICommanderRepo _repository; //this makes an instance of our interface and stores it in a private variable
        private readonly IMapper _mapper; //this makes an instance of IMapper from our AutoMapper dependecy 

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository; //when you set this up, you will have to generate a readonly field for _repository which is located above
            _mapper = mapper; //when you set this up, you will have to generate a readonly field for _mapper which is located above
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands(); //variable contains our command items from our repository
            
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));  //returns data in our CommandReadDto format and returns a 200 OK
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id); //variable contains our command item from our repository

            //This statement checks if the item id exists or not, if it doesnt exist, it will return a 404 Not Found
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem)); //returns data in our CommandReadDto format and returns a 200 OK
            } 
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges(); //this makes sure that the command created gets saved in our database

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            
            //this returns a specific route for the command with a unique id. This also returns a 201 Created response
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
 
             _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]

        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    } 
}