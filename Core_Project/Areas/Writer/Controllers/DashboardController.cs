using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.LastName;

            // Weather API
            string apiKey = "1afffa93efb6a2ad3a88cf38a52c2b9d";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Virginia&mode=xml&lang=eng&units=metric&appid=" + apiKey;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //statistics
            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
          
            return View();
        }
    }
}
