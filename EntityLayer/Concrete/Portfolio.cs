using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Portfolio
	{
		
        [Key]

        public int PorfolioID { get; set; }

        public string? Platform { get; set; }

        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        public string? ProjectUrl { get; set; }

        public string? BigImageUrl { get; set; }

        public string? Image1 { get; set; }

        public string? Image2 { get; set; }

        public string? Image3 { get; set; }

        public string? Image4 { get; set; }

        public int? Value { get; set; } 
    }
}

