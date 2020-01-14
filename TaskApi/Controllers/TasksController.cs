using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Repositories;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController: Controller
    {
        private readonly ITasksRepository taskRepository;

        public TasksController(ITasksRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            return Ok(taskRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromRoute] TaskItem taskItem)
        {
            return Created(
                Url.Action(nameof(Get), new {id=taskItem.Id}),
                taskRepository.Create(taskItem)
                );
        }
    }
}
