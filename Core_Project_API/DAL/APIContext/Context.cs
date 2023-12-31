using System;
using Core_Project_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Project_API.DAL.APIContext
{
	public class Context : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("server=localhost;userid=root;Password=root1234;database=CoreProjeDBAPI;PORT=3306");

        }

        public DbSet<Category> Categories { get; set; }
    }
}

