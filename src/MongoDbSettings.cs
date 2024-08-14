using System;
namespace TaskListAPI
{
	public class MongoDbSettings
	{
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}

