
using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class Board
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		//public int UserID { get; set; }

		//public ICollection<User> Collaborators { get; set; }
		public virtual ICollection<Task> Tasks { get; set; }
	}
}
