using System;
using System.ComponentModel.DataAnnotations;

namespace Core_Project_API.DAL.Entity
{
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
        public string CategoryName { get; set; }
       
	}
}

