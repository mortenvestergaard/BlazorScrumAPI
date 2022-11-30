using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class DbUser
	{
		[Key]
		public int Id { get; set; }
		public string Username { get; set; }

		public virtual ICollection<DbScrumTask> AssigneeTasks { get; set; }
		public virtual ICollection<DbScrumTask> ReporterTasks { get; set; }
	}
}
