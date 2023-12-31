using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Project_API.DAL.APIContext;
using Core_Project_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }

        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();

            if (c.Categories.Find(p.CategoryID) == null) {
                c.Add(p);
                c.SaveChanges();
                return Created("", p);
            }
            else
            {
                return Conflict(new { Message = "Already Exist!"});
            }

        }

        [HttpDelete]

        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]

        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var value = c.Find<Category>(p.CategoryID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return Ok(new {Message= "Updated Successfully", p });
            }
        }


    }

}
