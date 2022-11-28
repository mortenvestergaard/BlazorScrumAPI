using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class State
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Task> Tasks { get; set; }
	}
}
