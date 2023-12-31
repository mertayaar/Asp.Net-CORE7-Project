using System;
using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
	public class UserLoginViewModel
	{
		[Display(Name = "Username")]
		[Required(ErrorMessage ="Enter your username...!")]
		public required string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter your password...!")]
        public required string Password { get; set; }

    }
}

