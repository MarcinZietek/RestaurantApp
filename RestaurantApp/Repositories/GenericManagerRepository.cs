using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repositories
{
    public class GenericManagerRepository<T> : ITaskManager<T> where T : class

    {
        public void CompleteTask()
        {
            throw new NotImplementedException();
        }

        public string ReportTask()
        {
            throw new NotImplementedException();
        }

        public void ScheduleTask(T task)
        {
            throw new NotImplementedException();
        }
    }
}
