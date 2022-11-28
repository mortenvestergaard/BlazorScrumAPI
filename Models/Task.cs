using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int BoardID { get; set; }
		public int StateID { get; set; }
		public int AssigneeID { get; set; }
		public int ReporterID { get; set; }

		public Board? Board { get; set; }
		public State? State { get; set; }
		public User? Assignee { get; set; }
		public User? Reporter { get; set; }
	}
}
