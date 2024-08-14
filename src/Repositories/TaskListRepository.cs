using MongoDB.Driver;
using TaskListAPI.Models;

namespace TaskListAPI.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly IMongoCollection<TaskList> _taskLists;

        public TaskListRepository(IMongoDatabase database)
        {
            _taskLists = database.GetCollection<TaskList>("TaskLists");
        }

        public async Task<IEnumerable<TaskList>> GetTaskListsAsync(string userId, int page, int pageSize)
        {
            var filter = Builders<TaskList>.Filter.Or(
                Builders<TaskList>.Filter.Eq(tl => tl.OwnerId, userId),
                Builders<TaskList>.Filter.AnyEq(tl => tl.SharedWithUsers, userId)
            );
            return await _taskLists.Find(filter)
                                   .SortByDescending(tl => tl.CreatedAt)
                                   .Skip((page - 1) * pageSize)
                                   .Limit(pageSize)
                                   .ToListAsync();
        }

        public async Task<TaskList> GetTaskListByIdAsync(string id, string userId)
        {
            var filter = Builders<TaskList>.Filter.And(
                Builders<TaskList>.Filter.Eq(tl => tl.Id, id),
                Builders<TaskList>.Filter.Or(
                    Builders<TaskList>.Filter.Eq(tl => tl.OwnerId, userId),
                    Builders<TaskList>.Filter.AnyEq(tl => tl.SharedWithUsers, userId)
                )
            );
            return await _taskLists.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateTaskListAsync(TaskList taskList)
        {
            await _taskLists.InsertOneAsync(taskList);
        }

        public async Task UpdateTaskListAsync(TaskList taskList)
        {
            var filter = Builders<TaskList>.Filter.And(
                Builders<TaskList>.Filter.Eq(tl => tl.Id, taskList.Id),
                Builders<TaskList>.Filter.Eq(tl => tl.OwnerId, taskList.OwnerId)
            );
            await _taskLists.ReplaceOneAsync(filter, taskList);
        }

        public async Task DeleteTaskListAsync(string id, string userId)
        {
            var filter = Builders<TaskList>.Filter.And(
                Builders<TaskList>.Filter.Eq(tl => tl.Id, id),
                Builders<TaskList>.Filter.Eq(tl => tl.OwnerId, userId)
            );
            await _taskLists.DeleteOneAsync(filter);
        }

        public async Task AddUserToTaskListAsync(string taskListId, string userId)
        {
            var filter = Builders<TaskList>.Filter.Eq(tl => tl.Id, taskListId);
            var update = Builders<TaskList>.Update.AddToSet(tl => tl.SharedWithUsers, userId);
            await _taskLists.UpdateOneAsync(filter, update);
        }

        public async Task RemoveUserFromTaskListAsync(string taskListId, string userId)
        {
            var filter = Builders<TaskList>.Filter.Eq(tl => tl.Id, taskListId);
            var update = Builders<TaskList>.Update.Pull(tl => tl.SharedWithUsers, userId);
            await _taskLists.UpdateOneAsync(filter, update);
        }
    }
}

