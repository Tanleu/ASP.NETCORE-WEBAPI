using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assigment_2_Task.Enums;

namespace Assigment_2_Task.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [DisplayFormat(NullDisplayText = "No gender")]
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }

        public void Update(Person person)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.DateOfBirth = person.DateOfBirth;
            this.Gender = person.Gender;
            this.BirthPlace = person.BirthPlace;
        }
    }
}