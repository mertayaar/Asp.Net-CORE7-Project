using System;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace Core_Project.Models
{
	public class PortfolioViewModel
	{
        [Required(ErrorMessage = " Please select your platform image!")]
        public IFormFile? PlatformImage { get; set; }

        [Required(ErrorMessage = " Please select your project image!")]
        public IFormFile? ProjectImage { get; set; }
        public required int PortfolioID { get; set; }

        [Required(ErrorMessage = " Please enter your project name!")]
        public required string Name { get; set; }

        [Required(ErrorMessage = " Please enter your completion value!")]
        [Range(0, 100, ErrorMessage = "Completion must be between 0 and 100.")]
        public required int Completion { get; set; }
        public required string ProjectURL { get; set; }

    }
}
