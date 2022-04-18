using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace TaskManager
{   
    /// <summary>
    /// Klasa reprezentujaca kontekst bazy danych
    /// </summary>
    public class ToDoListContext : DbContext
    {

        public ToDoListContext()
            : base("name=ToDoListContext")
        {
            Database.SetInitializer(new ToDoListDbInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Task> Tasks { get; set; }
    }

    /// <summary>
    /// Klasa odpowiadajaca za inicjalizacje bazy danych wywolywana gdy baza danych nie istnieje
    /// </summary>
    public class ToDoListDbInitializer : CreateDatabaseIfNotExists<ToDoListContext>
    {   
        /// <summary>
        /// Funckja wpisujaca przykladowe dane do bazy danych
        /// </summary>
        /// <param name="context">Kontekst bazy danych</param>
        protected override void Seed(ToDoListContext context)
        {
            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = 1,
                    Name = "Testowe Zadanie",
                    StartDate = DateTime.Now,
                    Deadline = new DateTime(2022, 04, 09, 11, 15, 0),
                    Comment = "opis",
                    IsCompleted = false,
                },
                new Task()
                {
                    Id = 102,
                    Name = "Testowe Zadanie 2",
                    StartDate = DateTime.Now,
                    Deadline = new DateTime(2022, 04, 10, 12, 45, 0),
                    Comment = "opis 2",
                    IsCompleted = false,
                },
                new Task()
                {
                    Id = 103,
                    Name = "Testowe Zadanie 3",
                    StartDate = DateTime.Now,
                    Deadline = new DateTime(2022, 04, 20, 13, 45, 0),
                    Comment = "opis 3",
                    IsCompleted = false,
                }

            };
            tasks.ForEach(s => context.Tasks.Add(s));
            context.SaveChanges();
        }
    }
}