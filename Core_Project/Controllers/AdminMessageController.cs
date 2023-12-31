using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult AdminInbox()
        {
            string p;
            p = "mertayaar@gmail.com";
            var values = writerMessageManager.GetListInbox(p);
            return View(values);
        }

        public IActionResult AdminOutbox()
        {
            string p;
            p = "mertayaar@gmail.com";
            var values = writerMessageManager.GetListOutbox(p);
            return View(values);
        }


        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult DeleteAdminMessage(int id)
        {
            string p;
            p = "mertayaar@gmail.com";
            var values = writerMessageManager.TGetByID(id);
            if(values.Receiver == p)
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("AdminInbox");
            }
            else
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("AdminOutbox");
            }
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminSendMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            values.Content = "";
            values.Date = null;
            return View(values);
        }

        [HttpPost]

        public IActionResult AdminSendMessage(WriterMessage p)
        {
            p.Sender = "mertayaar@gmail.com";
            p.SenderName = "Admin";
            Context c = new Context();
            var userInfo = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.LastName).FirstOrDefault();
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ReceiverName = userInfo;

            writerMessageManager.TAdd(p);
            return RedirectToAction("AdminOutbox");
        }
    }
}