using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class ToDoList
	{

        [Key]

        public int ToDoListID { get; set; }

        public string? Content { get; set; }

        public bool? Status { get; set; }

    }
}

