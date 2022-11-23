﻿using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public State State { get; set; }
		public User AssignedTo { get; set; }
		public User Reporter { get; set; }
	}
}
