using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            writerUserManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            
            return Json(values);
        }


    
    }
 
}