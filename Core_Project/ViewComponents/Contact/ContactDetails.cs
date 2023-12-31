using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Views.Shared.Components.Contact
{
	public class ContactDetails : ViewComponent
	{
		ContactManager contactManager = new ContactManager(new EfContactDal());
		public IViewComponentResult Invoke()
		{
			var values = contactManager.TGetList();
			return View(values);
		}
		
	}
}

