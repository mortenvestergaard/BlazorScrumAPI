namespace BlazorScrumAPI.Models
{
	public class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public State State { get; set; }
		public User AssignedTo { get; set; }
		public User Reporter { get; set; }
	}
}
