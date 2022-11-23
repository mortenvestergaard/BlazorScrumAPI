using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class State
	{
		[Key]
		public int Id { get; set; }
		public States StateId { get; set; }
	}
}
