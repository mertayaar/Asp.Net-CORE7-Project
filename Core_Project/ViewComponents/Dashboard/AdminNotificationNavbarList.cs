using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
	public class AdminNotificationNavbarList : ViewComponent
	{
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IViewComponentResult Invoke()
        {
            var list = announcementManager.TGetList().OrderByDescending(x => x.AnnouncementID).Take(3).ToList();
            ViewBag.Count = announcementManager.TGetList().TakeLast(3).Count();
            return View(list);
        }
    }
}

