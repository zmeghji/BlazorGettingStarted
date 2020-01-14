using BlazorGettingStarted.Client;
using Microsoft.AspNetCore.Components;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Pages
{
    public class TaskOverviewBase :ComponentBase
    {
        [Inject]
        public IApiService Service1 { get; set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        protected override async Task OnInitializedAsync()
        {
            TaskItems = await Service1.GetTaskItems();
            await base.OnInitializedAsync();
        }
    }
}
