using Assigment_2_Task.Interfaces;
using Assigment_2_Task.Models;
using Assigment_2_Task.DataContexts;
using Assigment_2_Task.Enums;

namespace Assigment_2_Task.Services
{
    public class PersonService : IPersonService
    {
        private List<Person> Persons = DataContext.GetDataContext().Persons;

        public async Task<List<Person>> ListAsync()
        {
            return await Task.FromResult<List<Person>>(Persons);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            try
            {
                Persons.Add(person);
                return await Task.FromResult<Person>(person);
            }
            catch (Exception excpet)
            {
                throw excpet;
            }
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            try
            {
                var toUpdatePerson = Persons.FirstOrDefault(x => x.Id == person.Id);
                if (toUpdatePerson is null) throw new Exception("This person was deleted or doesn't exist");

                toUpdatePerson.Update(person);
                return await Task.FromResult<Person>(toUpdatePerson);
            }
            catch (Exception excpet)
            {
                throw excpet;
            }
        }

        public async Task<Person> DeleteAsync(Guid Id)
        {
            try
            {
                var toDeletePerson = Persons.FirstOrDefault(x => x.Id == Id);
                if (toDeletePerson is null) throw new Exception("This person was deleted or doesn't exist");
                Persons.Remove(toDeletePerson);
                return await Task.FromResult<Person>(toDeletePerson);
            }
            catch (Exception excpet)
            {
                throw excpet;
            }
        }

        public async Task<List<Person>> FilterPersonAsync(PersonFilterModel personFilterModel)
        {
            var filteredPersons = Persons;
            string filterName = personFilterModel.Name;
            Gender filterGender = personFilterModel.Gender;
            string filterBirthPlace = personFilterModel.BirthPlace;

            if(String.IsNullOrWhiteSpace(filterName) &&  filterGender == 0 && String.IsNullOrWhiteSpace(filterBirthPlace))
                return await Task.FromResult(filteredPersons);
            

            if(!String.IsNullOrWhiteSpace(personFilterModel.Name))
            {
                //Case sensitive
                //Equal
                
                filteredPersons = filteredPersons.Where(x => x.FirstName.Contains(personFilterModel.Name) || x.LastName.Contains(personFilterModel.Name)).ToList();
            }

            if(filterGender != 0)
            {
                filteredPersons = filteredPersons.Where(x => x.Gender == filterGender).ToList();
            }

            if(String.IsNullOrWhiteSpace(filterBirthPlace))
            {
                filteredPersons = filteredPersons.Where(x => x.BirthPlace.ToLower().Contains(filterBirthPlace)).ToList();
            }

            return await Task.FromResult(filteredPersons);
        }


    }
}