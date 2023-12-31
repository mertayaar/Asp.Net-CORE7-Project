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

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]

        public IActionResult Index()
        {
            var values = aboutManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]

        public IActionResult Index(About about)
        {

            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}