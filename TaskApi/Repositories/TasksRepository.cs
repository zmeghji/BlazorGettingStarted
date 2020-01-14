using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Repositories
{
    public interface ITasksRepository
    {
        List<TaskItem> Get();
        TaskItem Get(long id);
        TaskItem Create(TaskItem taskItem);

    }
    public class TasksRepository: ITasksRepository
    {
        private List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public TasksRepository()
        {
            for (var i = 0; i < 5; i++)
            {
                Tasks.Add(new TaskItem { Id = i, Name = $"{i}{i}{i}{i}{i}" });
            }
        }

        public List<TaskItem> Get()
        {
            return Tasks;
        }

        public TaskItem Get(long id)
        {
            return Tasks.Single(t => t.Id == id);
        }

        public TaskItem Create(TaskItem taskItem)
        {
            taskItem.Id = Tasks.Count() + 1;
            Tasks.Add(taskItem);
            return taskItem;
        }
    }
}
