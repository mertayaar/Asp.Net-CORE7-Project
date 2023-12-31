using System;
using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
	public class MessageList : ViewComponent
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            string p = "mertayaar@gmail.com";
            var list = (from x in context.Users
                        join y in context.WriterMessages
                        on x.Email equals y.Sender
                        where y.Receiver == p
                        select new WriterMessageImageUrl
                        {
                            ImageUrl = x.ImageURL,
                            Date = y.Date,
                            Name = y.SenderName,
                            Content = y.Content,
                            Id = y.WriterMessageID
                        }).OrderByDescending(x => x.Id).Take(3).ToList();

            return View(list);
        }
    }
}

