using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager
{
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
