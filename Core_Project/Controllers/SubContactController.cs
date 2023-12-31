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
    public class SubContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [HttpGet]

        public IActionResult Index()
        {
            var values = contactManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]

        public IActionResult Index(Contact contact)
        {

            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "SubContact");
        }
    }
}