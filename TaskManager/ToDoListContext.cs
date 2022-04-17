using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TaskManager
{
    public class ToDoListContext : DbContext
    {
        // Your context has been configured to use a 'ToDoListContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TaskManager.ToDoListContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToDoListContext' 
        // connection string in the application configuration file.
        public ToDoListContext()
            : base("name=ToDoListContext")
        {
            Database.SetInitializer(new ToDoListDbInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Task> Tasks { get; set; }
    }

    public class ToDoListDbInitializer : CreateDatabaseIfNotExists<ToDoListContext>
    {
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