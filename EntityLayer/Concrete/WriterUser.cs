using System;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
	public class WriterUser : IdentityUser<int>
	{
		public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? ImageURL { get; set; }

    }
}


 