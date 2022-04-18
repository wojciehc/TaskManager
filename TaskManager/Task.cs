using System;


namespace TaskManager
{   
    /// <summary>
    /// Klasa reprezentująca zadanie
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public string Comment { get; set; }
        public bool IsCompleted { get; set; }
    }

}
