using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Views.Shared.Components.Contact
{
	public class SendMessage : ViewComponent
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());

       

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }

    
    }
}

