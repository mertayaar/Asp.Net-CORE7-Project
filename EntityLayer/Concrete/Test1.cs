using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Test1
	{
		[Key]
		public int ID { get; set; }
        public string? Name { get; set; }
    }
}

