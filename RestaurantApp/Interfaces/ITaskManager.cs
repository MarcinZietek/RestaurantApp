using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Interfaces
{
    internal interface ITaskManager<T>
    {
        void ScheduleTask(T task);
        void CompleteTask();
        string ReportTask();
    }
}
