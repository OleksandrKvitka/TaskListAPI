using Microsoft.AspNetCore.Mvc;
using TaskListAPI.DTOs;
using TaskListAPI.Services;

namespace TaskListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _service;

        public TaskListController(ITaskListService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskLists([FromHeader] string userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var taskLists = await _service.GetTaskListsAsync(userId, page, pageSize);
            return Ok(taskLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskListById([FromHeader] string userId, string id)
        {
            var taskList = await _service.GetTaskListByIdAsync(id, userId);
            if (taskList == null)
            {
                return NotFound();
            }
            return Ok(taskList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskList([FromHeader] string userId, [FromBody] TaskListDto dto)
        {
            await _service.CreateTaskListAsync(userId, dto);
            return CreatedAtAction(nameof(GetTaskListById), new { id = dto.Name }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskList([FromHeader] string userId, string id, [FromBody] TaskListDto dto)
        {
            await _service.UpdateTaskListAsync(userId, id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList([FromHeader] string userId, string id)
        {
            await _service.DeleteTaskListAsync(userId, id);
            return NoContent();
        }

        [HttpPost("{id}/share")]
        public async Task<IActionResult> ShareTaskList([FromHeader] string userId, string id, [FromBody] string sharedUserId)
        {
            await _service.AddUserToTaskListAsync(userId, id, sharedUserId);
            return NoContent();
        }

        [HttpDelete("{id}/share/{sharedUserId}")]
        public async Task<IActionResult> UnshareTaskList([FromHeader] string userId, string id, string sharedUserId)
        {
            await _service.RemoveUserFromTaskListAsync(userId, id, sharedUserId);
            return NoContent();
        }
    }

}

