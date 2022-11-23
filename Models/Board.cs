﻿namespace BlazorScrumAPI.Models
{
	public class Board
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<User> Collaborators { get; set; }
		public virtual List<Models.Task> MyProperty { get; set; }
	}
}
