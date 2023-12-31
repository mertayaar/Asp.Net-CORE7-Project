using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Testimonial
	{
		
        [Key]

        public int TestimonialID { get; set; }

        public string? Name { get; set; }

        public string? Company { get; set; }

        public string? Comment { get; set; }

        public string? ImageUrl { get; set; }

        public string? Title { get; set; }
    }
}

