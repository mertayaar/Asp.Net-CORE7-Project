using System;
namespace Core_Project.Areas.Writer.Models
{
	public class WriterMessageImageUrl
	{
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
    }
}

