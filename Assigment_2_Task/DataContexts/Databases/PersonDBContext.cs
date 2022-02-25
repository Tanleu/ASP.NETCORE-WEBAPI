using Microsoft.EntityFrameworkCore;
using Assigment_2_Task.Models;
using Assigment_2_Task.Enums;

namespace Assigment_2_Task.DataContexts
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options) {}
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer();

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasData(
                new Person() {Id = Guid.NewGuid(), FirstName = "Tân", LastName = "Lều Duy", Gender = Gender.Male,DateOfBirth = new DateTime(2000,11,13), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Peter", LastName = "John", Gender = Gender.Female,DateOfBirth = new DateTime(1996,05,31), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Alan", LastName = "Ưalker", Gender = Gender.Trans,DateOfBirth = new DateTime(1967,07,25), BirthPlace="Hải Dương"},
                new Person() {Id = Guid.NewGuid(), FirstName = "Man", LastName = "IRON", Gender = Gender.Male,DateOfBirth = new DateTime(1796,12,11), BirthPlace="Hải Dương"}
            );
        }
    }
}