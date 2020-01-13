using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Models
{
    public class TaskItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static List<TaskItem> CreateTaskItems()
        {
            var taskItems = new List<TaskItem>();
            for (var i = 0; i < 5; i++)
            {
                taskItems.Add(new TaskItem { Id = i, Name = $"{i}{i}{i}{i}{i}" });
            }
            return taskItems;
        }

    }
}
