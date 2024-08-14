using TaskListAPI.DTOs;
using TaskListAPI.Models;
using TaskListAPI.Repositories;

namespace TaskListAPI.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _repository;

        public TaskListService(ITaskListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskList>> GetTaskListsAsync(string userId, int page, int pageSize)
        {
            return await _repository.GetTaskListsAsync(userId, page, pageSize);
        }

        public async Task<TaskList> GetTaskListByIdAsync(string id, string userId)
        {
            return await _repository.GetTaskListByIdAsync(id, userId);
        }

        public async Task CreateTaskListAsync(string userId, TaskListDto dto)
        {
            var taskList = new TaskList
            {
                Name = dto.Name,
                OwnerId = userId
            };
            await _repository.CreateTaskListAsync(taskList);
        }

        public async Task UpdateTaskListAsync(string userId, string id, TaskListDto dto)
        {
            var taskList = await _repository.GetTaskListByIdAsync(id, userId);
            if (taskList != null)
            {
                taskList.Name = dto.Name;
                await _repository.UpdateTaskListAsync(taskList);
            }
        }

        public async Task DeleteTaskListAsync(string userId, string id)
        {
            await _repository.DeleteTaskListAsync(id, userId);
        }

        public async Task AddUserToTaskListAsync(string userId, string taskListId, string sharedUserId)
        {
            var taskList = await _repository.GetTaskListByIdAsync(taskListId, userId);
            if (taskList != null)
            {
                await _repository.AddUserToTaskListAsync(taskListId, sharedUserId);
            }
        }

        public async Task RemoveUserFromTaskListAsync(string userId, string taskListId, string sharedUserId)
        {
            var taskList = await _repository.GetTaskListByIdAsync(taskListId, userId);
            if (taskList != null)
            {
                await _repository.RemoveUserFromTaskListAsync(taskListId, sharedUserId);
            }
        }
    }

}

