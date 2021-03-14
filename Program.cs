using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace HomeworkLesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create
            using (DatabaseContext context = new DatabaseContext())
            {
                var person = new Person();
                person.BirthDate = DateTime.Now;
                person.FirstName = "Test";
                person.LastName = "Test";
                person.MiddleName = "Test";
                context.People.Add(person);
                context.SaveChanges();
            }
            //Read
            using (var context = new DatabaseContext())
            {
                var people = context.People.ToList();
                foreach (var person in people)
                {
                    Console.WriteLine($"Name - {person.FirstName}\t Surname - {person.LastName}");
                }
            }
            //Update
            using (var context = new DatabaseContext())
            {
                var person = context.People.FirstOrDefault(p => p.Id == 3);
                if (person != null)
                {
                    person.FirstName = "updated";
                    context.SaveChanges();
                }
            }
            //Delete
            using (var context = new DatabaseContext())
            {
                var person = context.People.FirstOrDefault(p => p.Id == 4);
                if (person != null)
                {
                    context.People.Remove(person);
                    context.SaveChanges();
                }
            }
        }
    }
}