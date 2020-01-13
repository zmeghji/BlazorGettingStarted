using BlazorGettingStarted.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Pages
{
    public class TaskOverviewBase :ComponentBase
    {
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        protected override Task OnInitializedAsync()
        {
            for(var i =0; i<5; i++)
            {
                TaskItems.Add(new TaskItem { Id = i, Name = $"{i}{i}{i}{i}{i}" });
            }
            return base.OnInitializedAsync();
        }
    }
}
