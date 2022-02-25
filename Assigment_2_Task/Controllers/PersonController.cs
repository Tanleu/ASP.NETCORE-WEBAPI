
using Microsoft.AspNetCore.Mvc;
using Assigment_2_Task.Models;
using Assigment_2_Task.Interfaces;

namespace Assigment_2_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController: ControllerBase 
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("/api/persons")]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            try
            {
                return await _personService.ListAsync();
            }   
            catch(Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            try
            {
                return await _personService.CreateAsync(person);
            }   
            catch(Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Person>> UpdatePerson(Person person)
        {
            try
            {
                return await _personService.UpdateAsync(person);
            }   
            catch(Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> DeletePerson(Guid personId)
        {
            try
            {
                return await _personService.DeleteAsync(personId);
            }   
            catch(Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpPost]
        [Route("/api/persons/filter")]
        public async Task<ActionResult<List<Person>>> FilterPersons(PersonFilterModel condition)
        {
            try
            {
                return await _personService.FilterPersonAsync(condition);
            }   
            catch(Exception except)
            {
                return Problem(except.Message);
            }
            
        }        
    }
}