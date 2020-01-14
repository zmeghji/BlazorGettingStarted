using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorGettingStarted.Client
{
    public interface IApiService
    {
        Task<List<TaskItem>> GetTaskItems();
        Task<TaskItem> GetTaskItem(long id);
        Task<TaskItem> CreateTaskItem(TaskItem taskItem);
    }
    public class ApiService : IApiService
    {
        
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TaskItem> CreateTaskItem(TaskItem taskItem)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(taskItem));
            var resp = await _httpClient.PostAsync("tasks", stringContent);
            return JsonConvert.DeserializeObject<TaskItem>(await resp.Content.ReadAsStringAsync());
        }
        public async Task<TaskItem> GetTaskItem(long id)
        {
            var resp = await _httpClient.GetAsync($"tasks/{id}");
            var stringContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TaskItem>(stringContent);
        }
        public async Task<List<TaskItem>> GetTaskItems()
        {
            var resp = await _httpClient.GetAsync("tasks");
            var stringContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TaskItem>>(stringContent);
        }
    }
}
