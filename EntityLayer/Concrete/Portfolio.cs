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

        public int Value { get; set; } 
    }
}

