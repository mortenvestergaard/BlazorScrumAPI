using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class DbState
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<DbScrumTask> Tasks { get; set; }
	}
}
