using BlazorGettingStarted.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Pages
{
    public class TaskDetailBase : ComponentBase
    {
        [Parameter]
        public string TaskId { get; set; }
        public TaskItem TaskItem { get; set; }
        protected override Task OnInitializedAsync()
        {
            TaskItem = TaskItem.CreateTaskItems().Single(t => t.Id == Convert.ToInt32(TaskId));
            return base.OnInitializedAsync(); 
        }
    }
}