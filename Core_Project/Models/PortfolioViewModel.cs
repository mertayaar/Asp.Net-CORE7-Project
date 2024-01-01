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
        public  int PortfolioID { get; set; }

        [Required(ErrorMessage = " Please enter your project name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = " Please enter your completion value!")]
        [Range(0, 100, ErrorMessage = "Completion must be between 0 and 100.")]
        public int Completion { get; set; }

        [Required(ErrorMessage = " Please enter your project url!")]
        public string ProjectURL { get; set; }

        public string ImageUrl { get; set; }
        public string PlatformUrl { get; set; }


        public PortfolioViewModel(Portfolio portfolio)
        {
        
            PortfolioID = portfolio.PorfolioID;
            Name = portfolio.Name;
            Completion = portfolio.Value;
            ProjectURL = portfolio.ProjectUrl;
            ImageUrl = portfolio.ImageUrl;
            PlatformUrl = portfolio.Platform;

            // Map other properties as needed
        }

        // Parameterless constructor for model binding
        public PortfolioViewModel()
        {
        }
    }


}
