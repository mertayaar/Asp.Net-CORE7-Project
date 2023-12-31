using System;
using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
	public class AdminSidebarProfile :ViewComponent
	{
        WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            string p = "mertayaar@gmail.com";
            var values = writerUserManager.GetAdminProfile(p);

            ViewBag.AdminName = values[0].Name + " " + values[0].LastName;
            ViewBag.ImageUrl = values[0].ImageURL;
            return View(values);
        }
    }
}

