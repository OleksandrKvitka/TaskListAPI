using TaskListAPI.Models;

namespace TaskListAPI.Repositories
{
    public interface ITaskListRepository
    {
        Task<IEnumerable<TaskList>> GetTaskListsAsync(string userId, int page, int pageSize);
        Task<TaskList> GetTaskListByIdAsync(string id, string userId);
        Task CreateTaskListAsync(TaskList taskList);
        Task UpdateTaskListAsync(TaskList taskList);
        Task DeleteTaskListAsync(string id, string userId);
        Task AddUserToTaskListAsync(string taskListId, string userId);
        Task RemoveUserFromTaskListAsync(string taskListId, string userId);
    }
}

