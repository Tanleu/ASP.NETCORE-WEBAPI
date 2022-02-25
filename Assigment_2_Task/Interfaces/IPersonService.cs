using Assigment_2_Task.Models;

namespace Assigment_2_Task.Interfaces
{
    public interface IPersonService
    {
        public Task<List<Person>> ListAsync();
        public Task<Person> CreateAsync(Person person);
        public Task<Person> UpdateAsync(Person person);
        public Task<Person> DeleteAsync(Guid Id);
        public Task<List<Person>> FilterPersonAsync(PersonFilterModel personFilterModel);
    }
}