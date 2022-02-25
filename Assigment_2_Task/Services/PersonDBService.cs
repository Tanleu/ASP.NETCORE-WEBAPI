using Assigment_2_Task.Interfaces;
using Assigment_2_Task.Models;
using Assigment_2_Task.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Assigment_2_Task.Services
{
    public class PersonDbService : IPersonService
    {
        private readonly PersonDBContext _context;
        public PersonDbService(PersonDBContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            try
            {
                await _context.AddAsync<Person>(person);
                await _context.SaveChangesAsync();
            }
            catch(Exception except)
            {
                throw except;
            }
            return person;
        }

        public async Task<Person> DeleteAsync(Guid Id)
        {
            var toDeletePerson = await _context.Persons.FindAsync(Id);

            if(toDeletePerson == null)
                throw new Exception("This person was deleted");

            try
            {
                _context.Persons.Remove(toDeletePerson);
                await _context.SaveChangesAsync();
            }
            catch(Exception except)
            {
                throw except;
            }
            return toDeletePerson;
        }

        public Task<List<Person>> FilterPersonAsync(PersonFilterModel personFilterModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> ListAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var toUpdatePerson = await _context.Persons.FindAsync(person.Id);

            if(toUpdatePerson == null)
                throw new Exception("This person was deleted");

            try
            {
                _context.Entry(toUpdatePerson).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception except)
            {
                throw except;
            }
            return toUpdatePerson;
        }
    }
}