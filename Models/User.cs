using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Username { get; set; }
	}
}
