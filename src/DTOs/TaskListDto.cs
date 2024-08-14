namespace TaskListAPI.DTOs
{
	public class TaskListDto
	{
        public required string Name { get; set; }
        public List<string> Tasks { get; set; } = new List<string>();
    }
}

