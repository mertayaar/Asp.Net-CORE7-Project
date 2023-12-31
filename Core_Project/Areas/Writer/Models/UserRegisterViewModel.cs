using System;
using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
	public class UserRegisterViewModel
	{
        [Required(ErrorMessage = " Please enter your name!")]
        public required string Name { get; set; }
        [Required(ErrorMessage = " Please enter your last name!")]
        public required string LastName { get; set; }

        [Required(ErrorMessage =" Please enter your user name!")]
		public required string UserName { get; set; }

        [Required(ErrorMessage = " Please enter your password!")]
        public required string Password { get; set; }

        [Required(ErrorMessage = " Please enter your confrim password!")]
		[Compare("Password",ErrorMessage = "Passwords do not match!")]
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = " Please enter your email address!")]
        public required string Mail { get; set; }

        [Required(ErrorMessage = " Please enter your image URL!")]
        public required string ImageURL { get; set; }
    }
}

