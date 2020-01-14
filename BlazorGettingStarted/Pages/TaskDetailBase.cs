using BlazorGettingStarted.Client;
using Microsoft.AspNetCore.Components;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Pages
{
    public class TaskDetailBase : ComponentBase
    {
        [Inject]
        public IApiService Service1 { get; set; }

        [Parameter]
        public string TaskId { get; set; }
        public TaskItem TaskItem { get; set; }
        protected override async Task OnInitializedAsync()
        {
            TaskItem = await Service1.GetTaskItem(Convert.ToInt64(TaskId));
            await base.OnInitializedAsync(); 
        }
    }
}