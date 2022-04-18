using System;


namespace TaskManager
{   
    /// <summary>
    /// Klasa reprezentująca zadanie
    /// </summary>
    public class Task
    {   
        /// <summary>
        /// id zadania
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Nazwa zadania
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data poczatkowa
        /// </summary>
        public DateTime StartDate { get; set; }
       
        /// <summary>
        /// Data koncowa
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// komentarz - opis zadania
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// czy wykonane
        /// </summary>
        public bool IsCompleted { get; set; }
    }

}
