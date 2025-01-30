namespace MyFristApp.Models
{
	public class TaskViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string ClassName { get; set; } = null!;
		public DateTime Deadline { get; set; }
		public bool IsCompleted { get; set; }

	}
}
