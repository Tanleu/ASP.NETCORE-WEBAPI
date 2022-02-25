using Assigment_2_Task.Models;
using Assigment_2_Task.Enums;

namespace Assigment_2_Task.DataContexts
{
    public class DataContext
    {
        private static DataContext _dataContext;
        public List<Person> Persons;
        public DataContext()
        {
            Persons = PersonSeedingData();
        }
        public static DataContext GetDataContext()
        {
            if(_dataContext is null) _dataContext = new DataContext();
            return _dataContext;
        }

        private List<Person> PersonSeedingData()
        {
            List<Person> listPerson = new List<Person>() {
                new Person() {Id = Guid.NewGuid(), FirstName = "Tân", LastName = "Lều Duy", Gender = Gender.Male,DateOfBirth = new DateTime(2000,11,13), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Peter", LastName = "John", Gender = Gender.Female,DateOfBirth = new DateTime(1996,05,31), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Alan", LastName = "Ưalker", Gender = Gender.Trans,DateOfBirth = new DateTime(1967,07,25), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Man", LastName = "IRON", Gender = Gender.Male,DateOfBirth = new DateTime(1796,12,11), BirthPlace="Hải Dương"}
            };

            return listPerson;
        }
    }
}