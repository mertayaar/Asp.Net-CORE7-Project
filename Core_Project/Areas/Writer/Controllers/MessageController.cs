using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writerMessageManager.GetListInbox(p);


            return View(messagelist);
        }
        [Route("")]
        [Route("Outbox")]
        public async Task<IActionResult> Outbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writerMessageManager.GetListOutbox(p);


            return View(messagelist);
        }


        [Route("WriterMessageDetails/{id}")]
        public IActionResult WriterMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }

        [Route("OutboxMessageDetails/{id}")]
        public IActionResult OutboxMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
          
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async  Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.LastName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var username = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.LastName).FirstOrDefault();
            p.ReceiverName = username;
            writerMessageManager.TAdd(p);

            return RedirectToAction("Outbox");
        }
    }
}