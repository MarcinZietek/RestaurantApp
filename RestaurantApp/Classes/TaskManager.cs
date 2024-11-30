using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class TaskManager<T> : ITaskManager<T> 
    {
        private Queue<T> _queue = new Queue<T>();

        public void CompleteTask()
        {
            if (_queue.Count > 0)
            {
                var completedTask = _queue.Dequeue();
                Console.WriteLine($"Zadanie {completedTask} zostało zrealizowane.");
            }
        }

        public string ReportTask()
        {
            if (_queue.Count> 0) {

                return $"Zdania do realizacji: {_queue.Count}\n";
               }
            else
            {
                return $"Nie ma więcej zadań do realizacji: {_queue.Count}\n";
            }   
        }

        public void ScheduleTask(T task)
        {
            _queue.Enqueue(task);
            Console.WriteLine($"Zadanie {task} z powodzeniem dodane do listy zadań.\n");
        }

    }
}
