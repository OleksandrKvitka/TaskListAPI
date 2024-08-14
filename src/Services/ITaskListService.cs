using TaskListAPI.DTOs;
using TaskListAPI.Models;

namespace TaskListAPI.Services
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskList>> GetTaskListsAsync(string userId, int page, int pageSize);
        Task<TaskList> GetTaskListByIdAsync(string id, string userId);
        Task CreateTaskListAsync(string userId, TaskListDto dto);
        Task UpdateTaskListAsync(string userId, string id, TaskListDto dto);
        Task DeleteTaskListAsync(string userId, string id);
        Task AddUserToTaskListAsync(string userId, string taskListId, string sharedUserId);
        Task RemoveUserFromTaskListAsync(string userId, string taskListId, string sharedUserId);
    }
}

