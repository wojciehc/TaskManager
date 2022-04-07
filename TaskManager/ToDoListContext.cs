using System;
using System.Data.Entity;
using System.Linq;

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
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Task> Tasks { get; set; }
    }

    public class ToDoListDbInitializer : DropCreateDatabaseAlways<ToDoListContext>
    {
        protected override void Seed(ToDoListContext context)
        {   
            new Task()
            {
                Id = 101,
                Name = "Testowe Zadanie",
                StartDate = DateTime.Now,
                Deadline = new DateTime(2022, 04, 08, 11, 15, 0),
                Comment = "my name jef",
                IsCompleted = false,

            };
            context.SaveChanges();
        }
    }
}