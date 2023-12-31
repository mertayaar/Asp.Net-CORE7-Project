using System;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace Core_Project.Models
{
	public class PortfolioViewModel
	{
        public IFormFile? PlatformImage { get; set; }
        public IFormFile? ProjectImage { get; set; }
        public required int PortfolioID { get; set; }
        [Required(ErrorMessage = " Please enter your project name!")]
        public required string Name { get; set; }
        [Required(ErrorMessage = " Please enter your project URL!")]
        public required string ProjectURL { get; set; }

        [Required(ErrorMessage = " Please enter your completion value!")]
        public required string Completion { get; set; }

    }
}
